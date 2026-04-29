using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modul9_103022400081
{
    internal class BankTransferConfig
    {
       public Config config { get; set; }
        string path = "bank_transfer_config.json";

        public void LoadConfig()
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                config = JsonSerializer.Deserialize<Config>(jsonString);
            }
            else {
                setDefault();
                string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                }
        }

        public void setDefault()
        {
            config = new Config
            {
                lang = "en",
                transfer = new Transfer
                {
                    threshold = "25000000",
                    low_fee = "6500",
                    high_fee = "15000",

                },
                method = "RTO ( real time), SKN, RTGS, BI FAST",
                confirmation = new Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
        } 
    } 
}

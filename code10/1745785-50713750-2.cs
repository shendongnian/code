    using System;
    using Newtonsoft.Json;
    
    class Test
    {
        public static void Main()
        {
            string amount = "1000000";
            var obj = new
            {
                method = "submit",
                @params = new[]
                {
                    new
                    {
                        secret = "snL7AcZbKsHm1H7VjeZg7gNS55Xkd",
                        tx_json = new
                        {
                            Account = "rHSqhmuevNJg9ZYpspYHNnQDxraozuCk5p",
                            TransactionType = "PaymentChannelCreate",
                            Amount = amount,
                            Destination = "rD6CGd2uL9DZUVDNghMqAfr8doTzKbEtGA",
                            SettleDelay = 86400,
                            PublicKey = "023693F15967AE357D0327974AD46FE3C127113B1110D6044FD41E723689F81CC6",
                            DestinationTag = 20170428
                        },
                        fee_mult_max = 1000
                    }
                }
            };
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }
    }

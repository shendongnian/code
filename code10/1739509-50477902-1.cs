            static void Main(string[] args)
            {
                var secretKey = "secret";
                var payload = new
                {
                    vendor = new
                    {
                        email = "",
                        firstName = "",
                        lastName = ""
                    },
                    purchaseId = "12345678"
                };
                string payLoadString = JsonConvert.SerializeObject(payload);
                //NOTE:  C# uses UTF-8 by default, so this is the same as Encoding.Default.GetBytes();
                byte[] payLoadUTF8 = Encoding.UTF8.GetBytes(payLoadString);  
                string payLoadBase64 = Convert.ToBase64String(payLoadUTF8);
                string signatureBase64 = null;
                using (HMACSHA256 hmac = new HMACSHA256(Encoding.Default.GetBytes(secretKey)))
                {
                    byte[] hash = hmac.ComputeHash(payLoadUTF8);
                    signatureBase64 = Convert.ToBase64String(hash);
                }
                Console.WriteLine($"payLoadBase64:\t{payLoadBase64}");
                Console.WriteLine($"signatureBase64: \t{signatureBase64}");
                Console.ReadLine();
            }

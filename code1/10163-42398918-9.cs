    class Program
    {
        string key;
        static void Main(string[] args)
        {
            Program p = new Program();
            
            //get 16 byte key (just demo - typically you will have a predetermined key)
            p.key = AnotherAES.GetUniqueString(16);
            string plainText = "Hello World!";
            
            //encrypt
            string hex = p.Encrypt(plainText);
            //decrypt
            string roundTrip = p.Decrypt(hex);
            Console.WriteLine("Round Trip: {0}", roundTrip);
        }
        string Encrypt(string plainText)
        {
            Console.WriteLine("\nSending (encrypt side)...");
            Console.WriteLine("Plain Text: {0}", plainText);
            Console.WriteLine("Key: {0}", key);
            string hex = string.Empty;
            string ivString = AnotherAES.GetUniqueString(16);
            Console.WriteLine("IV: {0}", ivString);
            using (AnotherAES aes = new AnotherAES(key))
            {
                //encrypting side
                byte[] IV = Encoding.UTF8.GetBytes(ivString);
                //get encrypted bytes (IV bytes prepended to cipher bytes)
                byte[] encryptedBytes = aes.Encrypt(plainText, IV);
                byte[] encryptedBytesWithIV = IV.Concat(encryptedBytes).ToArray();
                //get hex string to send with url
                //this hex has both IV and ciphertext
                hex = BitConverter.ToString(encryptedBytesWithIV).Replace("-", "");
                Console.WriteLine("sending hex: {0}", hex);
            }
            return hex;
        }
        string Decrypt(string hex)
        {
            Console.WriteLine("\nReceiving (decrypt side)...");
            Console.WriteLine("received hex: {0}", hex);
            string roundTrip = string.Empty;
            Console.WriteLine("Key " + key);
            using (AnotherAES aes = new AnotherAES(key))
            {
                //get bytes from url
                byte[] encryptedBytesWithIV = AnotherAES.StringToByteArray(hex);
                byte[] IV = encryptedBytesWithIV.Take(16).ToArray();
                Console.WriteLine("IV: {0}", System.Text.Encoding.Default.GetString(IV));
                byte[] cipher = encryptedBytesWithIV.Skip(16).ToArray();
                roundTrip = aes.Decrypt(cipher, IV);
            }
            return roundTrip;
        }
    }

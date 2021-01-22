    static void Main(string[] args)
    {
        string plainText = "Hello World!";
        string key = AnotherAES.GetUniqueString(16);
        using (AnotherAES aes = new AnotherAES(key))
        {
            string IV = AnotherAES.GetUniqueString(16);
            byte[] byteIV = Encoding.UTF8.GetBytes(IV);
    
            byte[] receivedBytes = aes.Encrypt(plainText, byteIV);
            byte[] receivedIV = receivedBytes.Take(16).ToArray();
            byte[] receivedCipher = receivedBytes.Skip(16).ToArray();
    
            string roundTrip = aes.Decrypt(receivedCipher, byteIV);
            Console.WriteLine("Key: {0}", key);
            Console.WriteLine("IV: {0}", Encoding.UTF8.GetString(byteIV));
            Console.WriteLine("Plain Text: {0}", plainText);
            Console.WriteLine("Cipher Hex (to use in URL if needed): {0}", BitConverter.ToString(receivedCipher).Replace("-", ""));
            Console.WriteLine("Round Trip: {0}", roundTrip);
        }
    }

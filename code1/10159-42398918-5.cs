    static void Main(string[] args)
    {
        string plainText = "Hello World!";
        string key = AnotherAES.GetUniqueString(16);
        string IV = AnotherAES.GetUniqueString(16);
        Console.WriteLine("Plain Text: {0}", plainText);
        Console.WriteLine("Key: {0}", key);
        Console.WriteLine("IV: {0}", IV);
        using (AnotherAES aes = new AnotherAES(key))
        {
            //encrypting side
            byte[] byteIV = Encoding.UTF8.GetBytes(IV);
    
            Console.WriteLine("\nSending (encrypt side)...");
            //get encrypted bytes with IV prepended
            byte[] encryptedBytes_1 = aes.Encrypt(plainText, byteIV);
            byte[] encryptedBytes_1_IV = encryptedBytes_1.Take(16).ToArray();
            byte[] encryptedBytes_1_Cipher = encryptedBytes_1.Skip(16).ToArray();
            Console.WriteLine("sending encryptedBytes_1_Cipher Length: " + encryptedBytes_1_Cipher.Count());
    
            //get hex string to send with url
            string encryptedBytes_1_CipherHex = BitConverter.ToString(encryptedBytes_1).Replace("-", "");
            Console.WriteLine("sending encryptedBytes_1_CipherHex: {0}", encryptedBytes_1_CipherHex);
    
            //decrypting side
            Console.WriteLine("\nReceiving (decrypt side)...");
            //get bytes from url
            Console.WriteLine("received encryptedBytes_1_CipherHex: {0}", encryptedBytes_1_CipherHex);
            byte[] encryptedBytes_2 = AnotherAES.StringToByteArray(encryptedBytes_1_CipherHex);
            byte[] encryptedBytes_2_IV = encryptedBytes_2.Take(16).ToArray();
            byte[] encryptedBytes_2_Cipher = encryptedBytes_2.Skip(16).ToArray();
    
            Console.WriteLine("received encryptedBytes_2_Cipher Length: " + encryptedBytes_2_Cipher.Count());
            string roundTrip = aes.Decrypt(encryptedBytes_2_Cipher, encryptedBytes_2_IV);
            Console.WriteLine("Round Trip: {0}", roundTrip);
        }
    }

    public static byte[] EncryptOrDecrypt(byte[] text, byte[] key)
    {
        byte[] xor = new byte[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            xor[i] = (byte)(text[i] ^ key[i % key.Length]);
        }
        return xor;
    }
    static void Main(string[] args){
        string input;
        byte[] inputBytes;
        string inputKey;
        byte[] key;
        do
        {
            input = System.Console.ReadLine();
            inputBytes = Encoding.Unicode.GetBytes(input);
            inputKey = System.Console.ReadLine();
            key = Encoding.Unicode.GetBytes(inputKey);
            //byte[] key = { 0, 0 }; if key is 0, encryption will not happen
            byte[] encryptedBytes = EncryptOrDecrypt(inputBytes, key);
            string encryptedStr = Encoding.Unicode.GetString(encryptedBytes);
            byte[] decryptedBytes = EncryptOrDecrypt(encryptedBytes, key);
            string decryptedStr = Encoding.Unicode.GetString(decryptedBytes);
            System.Console.WriteLine("Encrypted string:");
            System.Console.WriteLine(encryptedStr);
            System.Console.WriteLine("Decrypted string:");
            System.Console.WriteLine(decryptedStr);
        } while (input != "-1" && inputKey != "-1");
        //test:
        //pavle
        //23
        //Encrypted string:
        //BRD_W
        //Decrypted string:
        //pavle
    }

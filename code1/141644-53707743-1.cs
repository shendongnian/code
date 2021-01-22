        public static byte[] EncryptOrDecrypt(byte[] text, byte[] key)
        {
            string xorStr = "";
            for (int i = 0; i < text.Length; i++)
            {
                xorStr += (char)(text[i] ^ key[i % key.Length]);
            }
            string[] newStrArray = xorStr.Split('\0');
            xorStr = string.Join("", newStrArray);
            return Encoding.Unicode.GetBytes(xorStr);
        }
        static void Main(string[] args){
                input = System.Console.ReadLine();
                inputBytes = Encoding.Unicode.GetBytes(input);
                byte[] key = { 1, 0 };
                byte[] cyptBytes = EncryptOrDecrypt(inputBytes, key);
                string cryptStr = Encoding.Unicode.GetString(cyptBytes);
                byte[] decrypBytes = EncryptOrDecrypt(cyptBytes, key);
                string decryptStr = Encoding.Unicode.GetString(decrypBytes);
                System.Console.WriteLine("Crypt string:");
                System.Console.WriteLine(cryptStr);
                System.Console.WriteLine("Decrypt string:");
                System.Console.WriteLine(decryptStr);
        }

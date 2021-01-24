    using System;
    using System.Text;
    
    namespace Tests
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Security.Cryptography.TripleDESCryptoServiceProvider tripleDES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                byte[] data = Encoding.UTF8.GetBytes("This is a sample message");
                byte[] key = Encoding.UTF8.GetBytes("NOSTROMOHASSOMEGODPOWERS");
                tripleDES.Key = key;
                tripleDES.IV = new byte[tripleDES.BlockSize / 8];
                var encryptor = tripleDES.CreateEncryptor();
                byte[] result = new byte[data.Length];
                result = encryptor.TransformFinalBlock(data, 0, data.Length);
                string res = BitConverter.ToString(result).Replace("-","");
                Console.WriteLine(BitConverter.ToString(result).Replace("-",""));
    
                byte[] data2 = result;
                tripleDES.Key = key;
                tripleDES.IV = new byte[tripleDES.BlockSize / 8];
                var decryptor = tripleDES.CreateDecryptor();
                byte[] result2 = new byte[data2.Length];
                result2 = decryptor.TransformFinalBlock(data2, 0, data2.Length);
                Console.WriteLine(Encoding.UTF8.GetString(result2));
            }
        }
    }

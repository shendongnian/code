    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            byte[] bytes = { 0x35, 0x24, 0x76, 0x12 };
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            Console.WriteLine(sb);
        }
    }

    using System;
     
    class Program
    {
     
        static void Main(string[] args)
        {
            string t = "爱虫";
            
            string s = "Test\ud800Test"; 
            byte[] dumpToBytes = GetBytes(s);
            string getItBack = GetString(dumpToBytes);
     
            foreach (char item in getItBack)
            {
                Console.WriteLine("{0} {1}", item, ((ushort)item).ToString("x"));
            }
     
            Console.ReadLine();
        }
        
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
     
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        
    }

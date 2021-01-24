        static byte [] ToByteArray(string str)
        {
            byte[] a = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                a[i] = (byte)str[i];
            }
            return a; 
        }
        static void Main(string[] args)
        {
            byte[] key = ToByteArray("abc");
            int i = 0;
            foreach (byte b in key)
            {
                System.Console.WriteLine("key[{0}] : {1}", i++, b);
            }
        }

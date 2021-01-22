        static void Main(string[] args)
        {
            String a = "Hello ";
            String b = " World! ";
            System.IO.MemoryStream ms = new System.IO.MemoryStream(20000 * b.Length + a.Length);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
            sw.Write(a);
            for (int i = 0; i < 20000; i++)
            {
                sw.Write(b);
            }
            ms.Seek(0,System.IO.SeekOrigin.Begin);
            System.IO.StreamReader sr = new System.IO.StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());
        }

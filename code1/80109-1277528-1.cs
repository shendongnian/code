        static void Main(string[] args)
        {
            Service1 s = new Service1();
            byte[] b = new byte[1024 * 512];
            for ( int i = 0 ; i < 160 ; i ++ )
            {
                Console.WriteLine(s.WriteChunk(b));
            }
        }

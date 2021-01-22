        static void Main(string[] args)
        {
            UInt32 us = 0x80004005;
            Int32 s = (Int32)us;
            Console.WriteLine("Unsigned {0}", us);
            Console.WriteLine("Signed {0}", s);
            Console.WriteLine("Signed as unsigned {0}", (UInt32)s);
            Console.ReadKey();
        }

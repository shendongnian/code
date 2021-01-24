    using System;
    using System.Text;
    namespace so49851713
    {
        class Program
        {
            public static void Main()
            {
                var mbb = "\u263Aআমার সোনার বাংলা!";
                /* prepare console (once per process) */
                Console.OutputEncoding = UTF8Encoding.UTF8;
                Console.WriteLine(mbb);
                Console.ReadLine();
            }
        }
    }

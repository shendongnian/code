    using System;
    class Test
    {   
        static void Main(string[] args)
        {
            int i=32;
            while (true)
            {
                Console.Write((char)i);
                i++;
                if (i == 127)
                {
                    i = 32;
                }
            }
        }
    }

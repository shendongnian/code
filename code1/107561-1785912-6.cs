    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static void Main()
        {
            bool oddLength = true;
            ulong start = 1;
            while (true)
            {
                for (ulong i = start; i < start * 10; ++i)
                {
                    string forwards = i.ToString();
                    string reverse = new string(forwards.ToCharArray()
                                                        .Reverse()
                                                        .Skip(oddLength ? 1 : 0)
                                                        .ToArray());
                    Console.WriteLine(forwards + reverse);
                }
                oddLength = !oddLength;
                if (oddLength)
                    start *= 10;
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    static class Program
    {
    
        static void Main()
        {
            Random rand = new Random(123456);
            int COUNT = 1000;
            Dictionary<Guid, int> guids = new Dictionary<Guid, int>(COUNT);
            Dictionary<string, int> strings = new Dictionary<string, int>(
                COUNT, StringComparer.Ordinal);
    
            byte[] buffer = new byte[16];
            for (int i = 0; i < COUNT; i++)
            {
                rand.NextBytes(buffer);
                Guid guid = new Guid(buffer);
                int val = rand.Next();
                guids.Add(guid, val);
                strings.Add(guid.ToString(), val);
            }
    
            for(int i = 0 ; i < 10 ; i++) {
                int index = rand.Next(COUNT);
                Guid guid = guids.Keys.Skip(index).First();
                Console.WriteLine("Searching for " + guid);
                int chk = 0;
                const int LOOP = 5000000;
                Stopwatch watch = Stopwatch.StartNew();
                for (int j = 0; j < LOOP; j++)
                {
                    chk += guids[guid];
                }
                watch.Stop();
                Console.WriteLine("As guid: " + watch.ElapsedMilliseconds
                       + "; " + chk);
                string key = guid.ToString();
                chk = 0;
                watch = Stopwatch.StartNew();
                for (int j = 0; j < LOOP; j++)
                {
                    chk += strings[key];
                }
                watch.Stop();
                Console.WriteLine("As string: " + watch.ElapsedMilliseconds
                       + "; " + chk);
            }
            Console.ReadLine();
            
        }
    }

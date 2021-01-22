    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UniqueKey;
    
    namespace CryptoRNGDemo
    {
        class Program
        {
    
            const int REPETITIONS = 1000000;
            const int KEY_SIZE = 32;
    
            static void Main(string[] args)
            {
                Console.WriteLine("Original BIASED implementation");
                PerformTest(REPETITIONS, KEY_SIZE, KeyGenerator.GetUniqueKeyOriginal_BIASED);
    
                Console.WriteLine("Updated implementation");
                PerformTest(REPETITIONS, KEY_SIZE, KeyGenerator.GetUniqueKey);
                Console.ReadKey();
            }
    
            static void PerformTest(int repetitions, int keySize, Func<int, string> generator)
            {
                Dictionary<char, int> counts = new Dictionary<char, int>();
                foreach (var ch in UniqueKey.KeyGenerator.chars) counts.Add(ch, 0);
    
                for (int i = 0; i < REPETITIONS; i++)
                {
                    var key = generator(KEY_SIZE); 
                    foreach (var ch in key) counts[ch]++;
                }
    
                int totalChars = counts.Values.Sum();
                foreach (var ch in UniqueKey.KeyGenerator.chars)
                {
                    Console.WriteLine($"{ch}: {(100.0 * counts[ch] / totalChars).ToString("#.000")}%");
                }
            }
        }
    }

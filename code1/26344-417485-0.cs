    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Test
    {
        static void Main()
        {
            Config config = new Config(10, 7, 5)
            {
                { new int?[]{null,  null,  null},  1},
                { new int?[]{1,     null,  null},  2},
                { new int?[]{9,     null,  null},  21},
                { new int?[]{1,     null,  3},     3 },
                { new int?[]{null,  2,     3},     4 },
                { new int?[]{1,     2,     3},     5 }
            };
            
            Console.WriteLine(config[1, 2, 3]);
            Console.WriteLine(config[3, 2, 3]);
            Console.WriteLine(config[8, 10, 11]);
            Console.WriteLine(config[1, 10, 11]);
            Console.WriteLine(config[9, 2, 3]);
            Console.WriteLine(config[9, 3, 3]);
        }
    }
    
    public class Config : IEnumerable
    {
        private readonly int[] priorities;
        private readonly List<KeyValuePair<int?[],int>> entries = 
            new List<KeyValuePair<int?[], int>>();
        
        public Config(params int[] priorities)
        {
            // In production code, copy the array to prevent tampering
            this.priorities = priorities;
        }
        
        public int this[params int[] keys]
        {
            get
            {
                if (keys.Length != priorities.Length)
                {
                    throw new ArgumentException("Invalid entry - wrong number of keys");
                }
                int bestValue = 0;
                int bestScore = -1;
                foreach (KeyValuePair<int?[], int> pair in entries)
                {
                    int?[] key = pair.Key;
                    int score = 0;
                    for (int i=0; i < priorities.Length; i++)
                    {
                        if (key[i]==null)
                        {
                            continue;
                        }
                        if (key[i].Value == keys[i])
                        {
                            score += priorities[i];
                        }
                        else
                        {
                            score = -1;
                            break;
                        }
                    }
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestValue = pair.Value;
                    }
                }
                return bestValue;
            }
        }
        
        public void Add(int?[] keys, int value)
        {
            if (keys.Length != priorities.Length)
            {
                throw new ArgumentException("Invalid entry - wrong number of keys");
            }
            // Again, copy the array in production code
            entries.Add(new KeyValuePair<int?[],int>(keys, value));
        }
        
        public IEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }

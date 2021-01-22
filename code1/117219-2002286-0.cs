    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace bitarray
    {
        class Program
        {
            private static Random rnd = new Random((int)DateTime.Now.Ticks);
    
            public static BitArray FlipRandomTrueBit(BitArray bits)
            {
                List<int> trueBits = new List<int>();
    
                for (int i = 0; i < bits.Count; i++)
                    if (bits[i])
                        trueBits.Add(i);
    
                if (trueBits.Count > 0)
                {
                    int index = rnd.Next(0, trueBits.Count);
                    bits[trueBits[index]] = false;
                }
    
                return bits;
            }
    
            public static int FlipRandomTrueBit(int input)
            {
                BitArray bits = new BitArray(new int[] { input });
                BitArray flipedBits = FlipRandomTrueBit(bits);
    
                byte[] bytes = new byte[4];
                flipedBits.CopyTo(bytes, 0);
    
                int result = BitConverter.ToInt32(bytes.ToArray(), 0);
                return result;
            }
    
            static void Main(string[] args)
            {
                int test = 382;
                for (int n = 0; n < 200; n++)
                {
                    int result = FlipRandomTrueBit(test);
                    Console.WriteLine(result);
                }
    
                Console.ReadLine();
            }
        }
    }

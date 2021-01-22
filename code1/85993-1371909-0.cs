    using System;
    
    class Test
    {
        static void Main()
        {
            Random rng = new Random();
            byte[,,] y = new byte[2,2,2];
            FillArray(y, rng);
        
            foreach (byte b in y)
            {
                Console.WriteLine(b);
            }
        }
        
        static void FillArray(byte[,,] array, Random rng)
        {
            byte[] tmp = new byte[array.Length];
            rng.NextBytes(tmp);
            Buffer.BlockCopy(tmp, 0, array, 0, tmp.Length);
        }
    }

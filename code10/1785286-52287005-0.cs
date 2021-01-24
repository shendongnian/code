        class Program
        {
            static List<byte> bytes = new List<byte>();
    
            static int maxElements = 400_000;
    
            static Random random = new Random();
    
            static int portionSize;
    
            static void Main(string[] args)
            {
                GenerateBytes();
    
                portionSize = maxElements / 4;
    
                ParallelLoopResult result = Parallel.For(0, 4, n =>
                 {
                     int portion = n * portionSize;
                     for (int i = portion; i < portion + portionSize; i++)
                     {
                         bytes[i] = (byte)(bytes[i] * 2);
                     }
                 });
    
                Console.WriteLine();
            }
    
            static void GenerateBytes()
            {
                for (int i = 0; i < maxElements; i++)
                {
                    bytes.Add((byte)random.Next(0, 11));
                }
            }

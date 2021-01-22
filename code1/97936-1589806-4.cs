    using System;
    
    class Test
    {
        const int Size = 100000;
        
        static void Main()
        {
            object[] array = new object[Size];
            long initialMemory = GC.GetTotalMemory(true);
            for (int i = 0; i < Size; i++)
            {
                array[i] = new string[0];
            }
            long finalMemory = GC.GetTotalMemory(true);
            GC.KeepAlive(array);
            
            long total = finalMemory - initialMemory;
            
            Console.WriteLine("Size of each element: {0:0.000} bytes",
                              ((double)total) / Size);
        }
    }

    private static unsafe void Main()
    {
       Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
    
       var arr = new int[100000];
    
       Console.WriteLine($"Total Memory after new : {GC.GetTotalMemory(false)}");
    
       try
       {
    
          fixed (int* p = arr)
          {
             *p = 1;
             throw new Exception("rah");
          }
    
       }
       catch 
       {
       }
    
       Console.WriteLine($"Generation: {GC.GetGeneration(arr)}, Total Memory: {GC.GetTotalMemory(false)}");
    
       arr = null;
       GC.Collect();
       GC.WaitForPendingFinalizers();
       Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
       Console.Read();
    }

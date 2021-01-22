    class Program
    {
      static int PropertyX { get; set; }
      
      static void Main()
      {
        PropertyX = 0;
        
        // Sugared from: 
        // WaitCallback w = (o) => WaitAndIncrement(500, ref PropertyX);
        WaitCallback w = (o) => {
          int x1 = PropertyX;
          WaitAndIncrement(500, ref x1);
          PropertyX = x1;
        };
        // end sugar
        
        ThreadPool.QueueUserWorkItem(w);
    
        // Sugared from: 
        // WaitAndIncrement(1000, ref PropertyX);
        int x2 = PropertyX;      
        WaitAndIncrement(1000, ref x2);
        PropertyX = x2;
        // end sugar
        
        Console.WriteLine(PropertyX);
      }
      
      static void WaitAndIncrement(int wait, ref int i)
      {
        Thread.Sleep(wait);
        i++;
      }
    }

    public Form1()
    {
       [DllImport("kernel32.dll")]
       public static extern bool AllocConsole();
    
       [DllImport("kernel32.dll")]
       public static extern bool FreeConsole();
    
       public Form1()
       {
          AllocConsole();
          Console.WriteLine("Whatever.");
       }
    }

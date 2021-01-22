    static void Main(string[] args)
    {
       while(true)
       {
         DoSomething();
         if(Console.KeyAvailable)
         {
            break;     
         }
         System.Threading.Thread.Sleep(60000);
       }
    }

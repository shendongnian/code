    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
              var perc = 0.0;
              while(perc <= 1.0)
              {
                Threading.Thread.Sleep(50); //simulate doing some work
                
                Console.Clear();
                Console.WriteLine(String.Format("{0:P}", perc));
                
                perc += 0.01;
              }
              Console.WriteLine("Press any key to exit");
              var exit = Console.ReadKey();
          }
      }
  }

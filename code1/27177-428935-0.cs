    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
          Console.WriteLine("starting");
          ShowBug(null);
          Console.WriteLine("finished");
          Console.ReadLine();
        }
    
        static void ShowBug(string x)
        {
            for (int j = 0; j < 10; j++)
            {
                if (String.IsNullOrEmpty(x))
                {
                    //TODO:
                }
            }
        }
    }

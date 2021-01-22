    using System;
    class Statmethod
    {
      //A class method declared
      static void show()
      {
        int x = 100;
        int y = 200;
        Console.WriteLine(x);
        Console.WriteLine(y);
      }
    
      public static void Main()
      {
        // Class method called without creating an object of the class
        Statmethod.show();
      }
    }

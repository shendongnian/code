    using System;
    class MainClass {
      public static void Main (string[] args) {
        Console.WriteLine("Please enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        while (number> 0)
        {
          Console.WriteLine("Steps");
          Console.WriteLine("--------------");
          Console.WriteLine("Digits: "+ (number % 10));
          sum = sum + (number % 10);
           Console.WriteLine("sum: "+ sum);
          number = number / 10;
          Console.WriteLine("number/10: "+ (number).ToString());
          Console.WriteLine("--------------");
        }
    Console.WriteLine("{0}{1}", "Sum of digits is: ", sum.ToString());
      }
    }

    private static void Main(string[] args)
    {
    
       //Actual Code
       while (true)
       {
          Console.WriteLine("Welcome to the Monthly Wage Calculator");
          Console.WriteLine("Please enter how much you are paid an hour");
    
          double hourlyWage;
          while (!double.TryParse(Console.ReadLine(), out hourlyWage))
             Console.WriteLine("You had one job, now answer the question properly");
    
          Console.WriteLine("Please enter how many hours you work a week");
    
          double hoursWorkedAWeek;
          while (!double.TryParse(Console.ReadLine(), out hoursWorkedAWeek))
             Console.WriteLine("You had one job, now answer the question properly");
    
          Console.WriteLine("Do you get paid (W)eekly or (B)iweekly?");
          var often = Console.ReadLine();
          while (often != "W" && often != "B")
          {
             Console.WriteLine("You had one job, now answer the question properly");
             often = Console.ReadLine();
          }
    
          if (often == "W")
             Console.WriteLine($"You will make {hoursWorkedAWeek * hourlyWage} on every paycheck");
          else if (often == "B")
             Console.WriteLine($"You will make {hoursWorkedAWeek * 2 * hourlyWage} on every paycheck");
    
          Console.WriteLine("Would you like to play again Y/N?");
    
          var repeat = Console.ReadLine();
          while (repeat != "Y" && repeat != "N")
          {
             Console.WriteLine("You had one job, now answer the question properly");
             repeat = Console.ReadLine();
          }
    
          if (repeat == "N")
          {
             Console.WriteLine("Suit yourself, goodbye");
             break;
          }
       }
    }

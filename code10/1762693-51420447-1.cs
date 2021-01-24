    static void Main(string[] args) {
      // Keep on working (execute switch case) ...
      for (bool keepOnWorking = true; keepOnWorking;) {
        Console.WriteLine("Type A to go to Fahrenheit Converter");
        Console.WriteLine("Type B to go to Coin Change");
        Console.WriteLine("Type C to go to Number Pattern");
        Console.WriteLine("Type X to exit");
        // Trim: let us be nice (what if user put/paste "A " or " B"?)
        string menuChoice = Console.ReadLine().Trim().ToUpper();
        switch (menuChoice) {
          case "A":
            fahrenheitConverter();
            break;
          case "B":
            break;
          case "C":
            break;
          case "D":
            break;
          case "X":
            // ... until user press "X". Stop working 
            keepOnWorking = false; 
            break; 
        }
      }  
    }

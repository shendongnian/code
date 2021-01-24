    // returning false signifies exit 
    public static bool EnterNumber(out int result)
    {
       result = 0;
    
       // read from the console
       var line = Console.ReadLine();
       while (true)
       {
          // if its exit return false
          if (line == "EXIT")
             return false;
    
          // its an int yay!!!! return true
          if (int.TryParse(line, out result))
             return true;
    
          // its a decimal, underscore means just discard the value
          if (decimal.TryParse(line, out _))
             Console.WriteLine("You just inputted a decimal value. Enter another value");
          else
             Console.WriteLine("Invalid Input. Try again.");
          line = Console.ReadLine();
       }  
    }

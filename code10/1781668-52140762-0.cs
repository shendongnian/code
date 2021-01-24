    private static int ReadValue(string title, 
                                 Func<int, bool> extraCondition = null, 
                                 string extraConditionText = null) {
      int result;
    
      while (true) { // keep on asking until correct input provided
        Console.WriteLine(title); 
    
        if (!int.TryParse(Console.ReadLine(), out result)) // syntax check
          Console.WriteLine("Syntax error, please, input integer value");
        else if (extraCondition != null && !extraCondition(result)) // extra check if any
          Console.WriteLine(string.IsNullOrEmpty(extraConditionText) 
            ? "Incorrect value" 
            : extraConditionText);
        else 
          return result;
      }
    }

     try {
        // Potential source of FormatException 
        num1 = int.Parse(Console.ReadLine());
        // Potential source of FormatException 
        num2 = int.Parse(Console.ReadLine());
        var opr = new operations();
        ...
     } 
     catch(FormatException) {
       Console.WriteLine("Input string was not in a correct format\nResult: 0");
     } 

    // In Program.Main (for example)
    Console.WriteLine("Enter the conversion in the form (Amount, Convert from, Convert to)");
    string input = Console.ReadLine();
    using (StreamReader reader = new StreamReader("../../convert.txt") 
    {
        string[] conversionSetting = this.FindConversionSetting(input, reader);
        if (conversionSetting != null) 
        {
            this.ConvertAndDisplayInput(input, conversionSetting );
        }
        else 
        {
            Console.WriteLine("Please enter two valid conversion types \n");
        }
    }

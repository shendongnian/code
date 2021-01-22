    private static void BinaryLiteralsFeature()
    {
        var employeeNumber = 0b00100010; //binary equivalent of whole number 34. Underlying data type defaults to System.Int32
        Console.WriteLine(employeeNumber); //prints 34 on console.
        long empNumberWithLongBackingType = 0b00100010; //here backing data type is long (System.Int64)
        Console.WriteLine(empNumberWithLongBackingType); //prints 34 on console.
        int employeeNumber_WithCapitalPrefix = 0B00100010; //0b and 0B prefixes are equivalent.
        Console.WriteLine(employeeNumber_WithCapitalPrefix); //prints 34 on console.
    }

    static void Main(string[] args)
    {
        var numbers = new []{ -1, 4, 9 };
        double sumOfRoots = numbers.Where(IsGreaterThanZero)   
                                   .Select(ToSquareRoot)      
                                   .Select(ToExp)              
                                   .Sum(x => ToNumber(x));
        Console.WriteLine($"sumOfRoots = {sumOfRoots}");
        Console.Read();
    }
    private static double ToNumber(double number)
    {
        Console.WriteLine($"SumNumber({number})");
        return number;
    }
    private static double ToSquareRoot(int number)
    {
        double value =  Math.Sqrt(number);
        Console.WriteLine($"Math.Sqrt({number}): {value}");
        return value;
    }
    private static double ToExp(double number)
    {
        double value =  Math.Exp(number);
        Console.WriteLine($"Math.Exp({number}): {value}");
        return value;
    }
    private static bool IsGreaterThanZero(int number)
    {
        bool isGreater = number > 0;
        Console.WriteLine($"{number} > 0: {isGreater}");
        return isGreater;
    }

    static void Main(string[] args)
    {
        var numbers = new List<double>();
        Console.WriteLine("Enter the three numbers, one per line");
        for (var i = 0; i < 3; ++i)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var enteredNumber))
                {
                    //the number is a number, so...
                    numbers.Add(enteredNumber);
                    break;
                }
                //if not a number...
                Console.WriteLine("That's not a number, try again");
            }
        }
        Average(numbers);
        Console.ReadKey();
    }
    static void Average(IEnumerable<double> numbers)
    {
        var average = numbers.Average();
        Console.Write("You have entered: ");
        foreach (var num in numbers)
        {
            Console.Write($" {num}  ");
        }
        Console.WriteLine(String.Empty);
        Console.WriteLine("The average is: " + average);
    }

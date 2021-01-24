    var input = new HashSet<int>();
    while (input.Count() < 5)
    {
        Console.WriteLine("enter value");
        int temp; // in newer c# it can be moved to the "out temp" => "out int tmep"
        if (Int32.TryParse(Console.ReadLine(), out temp))
        {
            input.Add(temp);
        }
        else
        {
            Console.WriteLine("incorrect value");
        }
    }
    foreach (var number in input.OrderBy(x => x))
    {
        Console.WriteLine(number);
    }

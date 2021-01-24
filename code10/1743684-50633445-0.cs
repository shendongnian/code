    Console.Write("Input numbers separated by + : ");
    string input = Console.ReadLine();
    int[] numbers = input.Split('+').Select(Int32.Parse).ToArray();
    foreach (var num in numbers )
    {
        Console.WriteLine(num);
    }

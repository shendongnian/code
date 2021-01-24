    Console.Write("How many numbers do you have?: ");
    int numberOfNumbers = int.Parse(Console.ReadLine()); // get user input, parse it
    int[] items = new int[numberOfNumbers];
    for (int i = 0; i < numberOfNumbers; ++i)
    {
        Console.Write("Enter number: ");
        items[i] = int.Parse(Console.ReadLine());
    }

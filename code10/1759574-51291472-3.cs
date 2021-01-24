    // My input for testing was 13.
    int n = int.Parse(Console.ReadLine());
    double total = 0;
    for (int i = n; i > 1; i -=4)
        total = Math.Sqrt(total + i);
    Console.WriteLine($"Total: {Math.Sqrt(++total)} = 1.980.");
    Console.ReadKey();

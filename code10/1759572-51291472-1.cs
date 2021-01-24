    // My input for testing was 13.
    int n = int.Parse(Console.ReadLine());
    double total = 0;
    for (int i = n; i > 1; i -=4)
        total += Math.Sqrt(i);
    Console.WriteLine($"Total: {++total} = 9.8416.");
    Console.ReadKey();

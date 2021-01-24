    Console.Write("Enter inital area: ");
    double initialArea = double.Parse(Console.ReadLine());
    Console.Write("Enter proportions, separate each proportion with spaces: ");
    string input = Console.ReadLine();
    double[] proportion = input.Split(' ').Select(x => double.Parse(x)).ToArray();
    int iterations = proportion.Length;
    Console.WriteLine($"Using {iterations} iterations");
    double[] area = new double[proportion.Length + 1];
    area[0] = initialArea;
    for (int i = 1; i <= iterations; i++)
    {
        Console.Write($"Iteration = {i}: ");
        for (int n = 0; n < i; n++)
        {
            area[i] += area[n] * proportion[i - n - 1];
            Console.Write($"area[{n}] = {area[n]} ");
        }
        Console.WriteLine();
    }
    Console.ReadLine();

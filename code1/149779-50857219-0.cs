    // Somewhat better code...
    Random rng = new Random();
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(GenerateDigit(rng));
    }
    ...
    static int GenerateDigit(Random rng)
    {
        // Assume there'd be more logic here really
        return rng.Next(10);
    }

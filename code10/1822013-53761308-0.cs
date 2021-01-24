    static void Multiply()
    {
        int[] input = { 2, 3, 6, 8 };
        int[] result = { 1, 1, 1, 1 };
        var product = input.Aggregate((i, j) => i * j);
        for (int i = 0; i < input.Length; i++)
        {
            result[i] = product / input[i];
        }
        Console.WriteLine(string.Join(" ", input));
        Console.WriteLine(string.Join(" ", result));
        Console.ReadKey();
    }

    private static void Main(string[] args)
    {
        var array = new string[5, 5];
        for (var y = 0; y < array.GetLength(1); y++)
        {
            for (var x = 0; x < array.GetLength(0); x++)
            {
                array[x, y] = string.Format("({0}|{1})", x, y);
            }
        }
        foreach (var window in GetWindows(array, 3, 3))
        {
            ShowArray(window);
        }
        Console.ReadLine();
    }
    private static void ShowArray<T>(T[,] array)
    {
        for (var x = 0; x < array.GetLength(0); x++)
        {
            for (var y = 0; y < array.GetLength(1); y++)
            {
                Console.Write("    {0}", array[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

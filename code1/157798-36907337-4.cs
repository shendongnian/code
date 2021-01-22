    int[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
    foreach (var i in array.Indices(0))
    {
        foreach (var j in array.Indices(1))
        {
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
    }

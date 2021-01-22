    int[,] array = { { 1, 2, 3 }, { 4, 5, 6 } };
    for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
    {
        for (var j= array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
        {
            Console.Write(array[i, j]);
        }
        Console.WriteLine();
    }

    public static IEnumerable<T> TraverseTransposed<T>(this T[,] array)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            for (int i = 0; i < array.GetLength(0); i++)
                yield return array[i, j];
    }

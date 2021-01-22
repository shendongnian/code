    public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
    {
        for (var i = 0; i < array.GetLength(0); i++)
        {
            yield return array[i, row];
        }
    }
    double[,] prices = ...;
    double[] secondRow = prices.SliceRow(1).ToArray();

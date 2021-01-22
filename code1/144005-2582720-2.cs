    public static double[] GetMaxForAllRows(double[,] arr, int rowIndex)
    {
        return (from row in Enumerable.Range(0, arr.GetLength(0))
                let cols = Enumerable.Range(0, arr.GetLength(1))
                select cols.Max(col => arr[row, col])).ToArray();
    }

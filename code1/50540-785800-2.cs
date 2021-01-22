    public static IEnumerable<T> Slice(this T[,] values)
    {
        return Slice(values, 0, 0);
    }
    public static IEnumerable<T> Slice(this T[,] values, int index)
    {
        return Slice(values, 0, index);
    }
    public static IEnumerable<T> Slice(this T[,] values, int dimension, int index)
    {
        int length = values.GetUpperBound(dimension);
        int[] point = new int[values.Rank];
        point[dimension] = index;
        dimension = 1 - dimension;// only works for rank == 2
        for (int i = 0; i < length; i++)
        {
            point[dimension] = i;
             yield return (T)values.GetValue(point);
        }
    }

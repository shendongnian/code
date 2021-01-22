    public static T Get2DArrayValueByPosition<T> (T[,] arr, int position)
    {
        // Gets the size of the array in first dimention
        step  = arr.GetUpperBound(0) + 1;
        return arr[(position / step ), position % step];
    }

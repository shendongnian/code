    public static int[,] GetMatrixFromUser()
    {
        var size = GetMatrixSize();
        return GetMatrixValues(size.Rows, size.Columns);
    }

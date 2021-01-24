    public static int[,] GetMatrixFromUser()
    {
        (int Rows, int Columns) size;
        do
        {
            size = GetMatrixSize();
        } while (!IsValid(size.Rows, 
                          1,
                          int.MaxValue, 
                          "Number of rows must be equal or greather than one") |
                 !IsValid(size.Columns, 
                          1, 
                          int.MaxValue, 
                          "Number of columns must be equal or greather than one"));
        return GetMatrixValues(size.Rows, size.Columns);
    }

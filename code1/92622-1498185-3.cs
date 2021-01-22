    public static TResult[,] CloneBase0<TSource, TResult>(
        this TSource[,] sourceArray)
    {
        If (sourceArray == null)
        {
            throw new ArgumentNullException(
                "The 'sourceArray' is null, which is invalid.");
        }
        int numRows = sourceArray.GetLength(0);
        int numColumns = sourceArray.GetLength(1);
        TResult[,] resultArray = new TResult[numRows, numColumns];
        int lb1 = sourceArray.GetLowerBound(0); 
        int lb2 = sourceArray.GetLowerBound(1); 
        for (int r = 0; r < numRows; r++)
        {
            for (int c = 0; c < numColumns; c++)
            {
                resultArray[r, c] = sourceArray[lb1 + r, lb2 + c];
            }
        }
        return resultArray;
    }

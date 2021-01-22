    public static T[,] SubMatrix(this T[,] matrix, int xstart, int ystart)
    {
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
    
        if (xstart < 0 || xstart >= width)
        {
            throw new ArgumentOutOfRangeException("xstart");
        }
        else if (ystart < 0 || ystart >= height)
        {
            throw new ArgumentOutOfRangeException("ystart");
        }
    
        T[,] submatrix = new T[width - xstart, height - ystart];
    
        for (int i = xstart; i < width; ++i)
        {
            for (int j = ystart; j < height; ++j)
            {
                submatrix[i - xstart, j - ystart] = matrix[i, j];
            }
        }
    
        return submatrix;
    }

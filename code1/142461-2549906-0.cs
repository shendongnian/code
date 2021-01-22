    void copy(int[][] source, int[][] destination, int startRow, int startCol)
    {
        for (int i = 0; i < source.Length; ++i)
        {
            int[] row = source[i];
            for (int j = 0; j < row.Length; ++j)
            {
                destination[i + startRow][j + startCol] = row[j];
            }
        }
    }

    //generic function
    public static int CountRow<T>(T[,] table, int col)
    {
        if (table == null || col < 0 || col >= table.GetLength(1)) 
        {
            //handle error
            return -1;
        }
        //this is the same as the block of the outer for loop
        int sum = 0;
        for (int row = 0; row < table.GetLength(1); row++)
        {
            if(table[col,row] != null)
            {
                sum++;
            }
        }
        return sum;
    }

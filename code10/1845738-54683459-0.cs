    static int NextSpaceAvailable(int[,] array) 
    {
     for (var row = 0; row < array.GetLength(0); ++row)
     {      
       if (array[row, 2] = 0)
       {
           //This space is available
           return row;
       }
     }
     return -1;
    }

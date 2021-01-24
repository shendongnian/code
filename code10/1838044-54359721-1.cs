      public static void fill2DArray(int[,] arr){
        int numRows = arr.GetLength(0);
        int numCols = arr.GetLength(1);
        for(int i = 0; i < numRows; ++i){
            for(int j = 0; j < numCols; ++j){
                arr[i,j] = 0;
            }
        }
    }

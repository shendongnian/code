    int[,] arr =  { 
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                  };
     for(int i = 0; i < arr.GetLength(0); i++){
          for (int j = 0; j < arr.GetLength(1); j++)
               Console.Write( "{0}\t",arr[i, j]);
          Console.WriteLine();
        }
    output:  1  2  3
             4  5  6
             7  8  9

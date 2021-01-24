    static void updateById<T>(string[,] matrix)
    {
       int pos = searchId(matrix);
       if (pos != -1)
       {
          for (int i = pos; i < pos + 1; i++)
          {
             for (int j = 1; j < matrix.GetLength(1); j++)
             {
                Console.Write($"Insert {GetHeader<T>(j)}:  ");
                ...

    static void deleteByid(ref string[,] matrix)
    {
        int pos = searchId(matrix);
        int newRowCount = 0;
    
        if (pos != -1)
        {
            var newArray = new string[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int n = 0; n < matrix.GetLength(0) - 1; n++)
            {
                if (pos != n)
                {
                    for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                    {
                        newArray[newRowCount, i] = matrix[n, i];
                    } 
                    newRowCount++;
                }
            } 
            matrix = newArray;
        }
        else { Console.WriteLine("ID does not exist"); }
    }

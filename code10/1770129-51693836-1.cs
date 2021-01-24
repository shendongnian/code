    static void insertStudent(string[,] matrix)
    {
        int id = generateId();
        int n = getInsertIndex(matrix);
    
        matrix[n, 0] = Convert.ToString(id);
    
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            do
            {
                Console.Write($"Insert {Enum.GetName(typeof(dataInsert), j)}: ");
                matrix[n, j] = Console.ReadLine();
            } while (String.IsNullOrEmpty(matrix[n, j]));
        }
    }

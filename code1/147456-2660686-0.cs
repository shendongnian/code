    static string ArrayToString<T>(T[,] array)
    {
        StringBuilder builder = new StringBuilder("{");
    
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (i != 0) builder.Append(",");
            builder.Append("{");
    
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j != 0) builder.Append(",");
                builder.Append(array[i, j]);
            }
    
            builder.Append("}");
        }
    
        builder.Append("}");
    
        return builder.ToString();
    }

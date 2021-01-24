    pubic static T[][] Transpose<T>(T[][] arrays)
    {
        // sanity checks omitted
        var columns = arrays.Length;
        var rows = arrays.Select(x => x.Length).Max();
    
        var matrix = new T[rows][];
    
        for (var row = 0; row < rows; row++)
        {
            matrix[row] = new T[columns];
    
            for (var column = 0; column < columns; column++)
            {
                // proper bounds checks omitted
                matrix[row][column] = arrays[column][row];
            }
        }
    
        return matrix;
    }

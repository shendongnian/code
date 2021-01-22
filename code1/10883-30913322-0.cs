    private static string GetColumnLetter(string colNumber)
    {
        if (string.IsNullOrEmpty(colNumber))
        {
            throw new ArgumentNullException(colNumber);
        }
        string colName = String.Empty;
        try
        {
            var colNum = Convert.ToInt32(colNumber);
            var mod = colNum % 26;
            var div = Math.Floor((double)(colNum)/26);
            colName = ((div > 0) ? GetColumnLetter((div - 1).ToString()) : String.Empty) + Convert.ToChar(mod + 65);
        }
        finally
        {
            colName = colName == String.Empty ? "A" : colName;
        }
        return colName;
    }

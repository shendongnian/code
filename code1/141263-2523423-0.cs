    public static string GetColumnName(int columnNumber)
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string columnName = "";
        while (columnNumber > 0)
        {
            columnName = letters[(columnNumber - 1) % 26] + columnName;
            columnNumber = (columnNumber - 1) / 26;
        }
        return columnName;
    }

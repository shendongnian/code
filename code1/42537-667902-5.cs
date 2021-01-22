    public static int ExcelColumnNameToNumber(string columnName)
    {
        if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");
    
        columnName = columnName.ToUpperInvariant();
    
        int sum = 0;
    
        for (int i = 0; i < columnName.Length; i++)
        {
            sum *= 26;
            sum += (columnName[i] - 'A' + 1);
        }
    
        return sum;
    }

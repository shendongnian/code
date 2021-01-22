    public static int ExcelColumnNameToNumber(string columnName)
    {
        if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");
    
        char[] characters = columnName.ToUpperInvariant().ToCharArray();
    
        int sum = 0;
    
        for (int i = 0; i < characters.Length; i++)
        {
            sum *= 26;
            sum += (characters[i] - 'A' + 1);
        }
    
        return sum;
    }

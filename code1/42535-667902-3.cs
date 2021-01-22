    public static int ExcelColumnNameToNumber(string columnName)
    {
        if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");
    
        char[] characters = columnName.ToUpperInvariant().ToCharArray();
    
        int sum = 0;
    
        for (int i = 0; i < characters.Length; i++)
        {
            sum += (characters[i] - 'A' + 1) * Convert.ToInt32(Math.Pow(26.0, characters.Length - i - 1));
        }
    
        return sum;
    }

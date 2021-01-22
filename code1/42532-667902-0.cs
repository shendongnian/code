    public int ExcelColumnNameToNumber(string columnName)
    {
        if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");
    
        char[] characters = columnName.ToUpperInvariant().ToCharArray();
    
        int sum = 0;
    
        for (int i = 0; i < characters.Length; i++)
        {
            int characterValue = Convert.ToInt32(characters[i]) - Convert.ToInt32('A') + 1;
            sum += characterValue * Convert.ToInt32(Math.Pow(26.0, characters.Length - i));
        }
    
        return sum;
    }

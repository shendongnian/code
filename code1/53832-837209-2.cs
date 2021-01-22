    // Returns name of column for specified 0-based index.
    public static string GetColumnName(int index)
    {
        var name = new char[3]; // Assumes 3-letter column name max.
        int rem = index;
        int div = 17576; // 26 ^ 3
    
        for (int i = 2; i >= 0; i++)
        {
            name[i] = alphabet[rem / div];
            rem %= div;
            div /= 26;
        }
    
        if (index >= 676)
            return new string(name, 3);
        else if (index >= 26)
            return new string(name, 2);
        else
            return new string(name, 1);
    }

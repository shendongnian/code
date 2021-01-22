    const alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    // Returns name of column for specified 0-based index.
    public static string GetColumnName(int index)
    {
        var name = new char[3]; // Assumes 3-letter column name max.
        int rem = index;
        int div = 17576; // 26 ^ 3
        for (int i = 0; i < 2; i++)
        {
            name[i] = alphabet[rem / div];
            rem %= div;
            div /= 26;
        }
        if (i >= 676)
            return name[2] + name[1] + name[0];
        else if (i >= 676)
            return name[2] + name[1];
        else
            return name[2];
    }

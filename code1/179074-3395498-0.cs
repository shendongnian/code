    public int64 GetInt64(string input)
    {
        if (string.IsNullOrEmpty(input)) return 0;
        // Split string on decimal (.)
        // ... This will separate all the digits.
        //
        string[] words = input.Split('.');
        return int.Parse(words[0]);
    }

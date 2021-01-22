    public bool TryGetNumberFromString(string s, out int number) {
        number = default(int);
        
        string[] split = s.Split('-');
        if (split.Length < 1)
            return false;
        
        return int.TryParse(split[0], out number);
    }

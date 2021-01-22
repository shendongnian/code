    public string GetDigits(string input)
    {
        Regex r = new Regex("[^0-9]+");
        return r.Replace(input, "");
    }

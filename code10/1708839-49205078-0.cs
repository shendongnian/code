    //For chinese chars
    public bool IsChinese(string text)
    {
        return text.Any(c => c >= 0x20000 && c <= 0xFA2D);
    }
    
    //For japanese chars
    private static IEnumerable<char> GetCharsInRange(string text, int min, int max)
    {
        return text.Where(e => e >= min && e <= max);
    }

    static bool IsValid(string input)
    {
            var strings = input.Split(",");
            if (strings.Any(n => int.Parse(n) <= 0 || int.Parse(n) >= 31)) return false;      
            return new HashSet<string>(strings).Count == strings.Length;
    }

    private static List<string> GetCodes(string input)
    {
        return input?.Split().Where(word => 
            word.Length == 7 &&
            word.Take(3).All(char.IsLetter) && 
            word.Skip(3).Take(4).All(char.IsNumber))
            .ToList();
    }

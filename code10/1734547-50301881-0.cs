    private static string GetCode(string input)
    {
        return input?.Split().FirstOrDefault(word => 
            word.Length == 7 &&
            word.Take(3).All(char.IsLetter) && 
            word.Skip(3).Take(4).All(char.IsNumber));
    }

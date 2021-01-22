    var query = strings.Where(IsFiveCharacters);
    ...
 
    private bool IsFiveCharacters(string input)
    {
        return input.Length == 5;
    }

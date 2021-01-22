    private string MakeUrlString(string input)
    {
        var array = input.ToCharArray();
        array = Array.FindAll<char>(array, c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-');
        var newString = new string(array).Replace(" ", "-").ToLower();
        return newString;
    }

    var str = "freq12";
    int splitIndex;
    for(splitIndex = 0; splitIndex < str.Length; splitIndex++)
    {
        if (char.IsNumeric(str[splitIndex]))
            break;
    }
    if (splitIndex == str.Length)
        throw new InvalidOperationException("The input string does not contain a numeric part.");
    var textPart = int.Parse(str.Substring(0, splitIndex));
    var numPart = int.Parse(str.Substring(splitIndex));

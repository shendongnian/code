    using System.Text.RegularExpressions; //https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2
    //...
    readonly Regex isNumeric = new Regex("^[+-]?\d*\.?\d*$", RegexOptions.Compiled); //treat "." as "0.0", ".9" as "0.9", etc
    readonly Regex isInteger = new Regex("^[+-]?\d+$", RegexOptions.Compiled); //requires at least 1 digit; i.e. "" is not "0" 
    readonly Regex isIntegerLike = new Regex("^[+-]?\d*\.?\0*$", RegexOptions.Compiled); //same as integer, only 12.0 is treated as 12, whilst 12.1 is invalid; i.e. only an integer if we can remove digits after the decimal point without truncating the value.
    //...
    public bool IsNumeric(string input)
    {
        return isNumeric.IsMatch(input); //if you'd wanted 4.4 to be true, use this
    }
    public bool IsInteger(string input)
    {
        return isInteger.IsMatch(input); //as you want 4.4 to be false, use this
    }
    public bool IsIntegerLike(string input)
    {
        return isIntegerLike.IsMatch(input); //4.4 is false, but both 4 and 4.0 are true 
    }

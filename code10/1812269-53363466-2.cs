    using System.Text.RegularExpressions; //https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2
    //...
    readonly Regex isNumeric = new Regex("^[+-]?\d*\.\d*$", RegexOptions.Compiled);
    readonly Regex isInteger = new Regex("^[+-]?\d*$", RegexOptions.Compiled);
    //...
    public bool IsNumeric(string input)
    {
        return isNumeric.IsMatch(input); //if you'd wanted 4.4 to be true, use this
    }
    public bool IsInteger(string input)
    {
        return isInteger.IsMatch(input); //as you want 4.4 to be false, use this
    }

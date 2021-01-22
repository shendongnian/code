    using System.Text.RegularExpressions;
    public string[] Split(string expression, string delimiter, string qualifier, bool ignoreCase)
    {
        string _Statement = String.Format("{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))", 
                            Regex.Escape(delimiter), Regex.Escape(qualifier));
    
        RegexOptions _Options = RegexOptions.Compiled | RegexOptions.Multiline;
        if (ignoreCase) _Options = _Options | RegexOptions.IgnoreCase;
    
        Regex _Expression = New Regex(_Statement, _Options);
        return _Expression.Split(expression);
    }

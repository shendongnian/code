    using System.Text.RegularExpressions;
    private bool ContainsHTML(string CheckString)
    {
      return Regex.IsMatch(CheckString, "<(.|\n)*?>");
    }

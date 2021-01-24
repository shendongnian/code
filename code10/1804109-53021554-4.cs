    @using System.Text.RegularExpressions;
    
    @helper StripHTML(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            input = Regex.Replace(input, "<.*?>", String.Empty);
            <span>@input</span>
        }
    }

    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"<!--.*?-->|(<\s*\w+[^>]*>)";
            string input = @"<a key=""a"" value=""b""/><b key=""b"" value=""b""/><!--<c key=""c"" value=""c""/>-->
    <d key=""d"" value=""d""/>";
            RegexOptions options = RegexOptions.Multiline;
    
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                if(m.Groups[1].Success)
                    Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }

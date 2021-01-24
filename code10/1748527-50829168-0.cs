    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?<=HYPERLINK\(CONCATENATE\("")[^""]+";
            string input = @"=HYPERLINK(CONCATENATE(""https://abc.efghi.rtyui.com/#/wqeqwq/"",#REF!,""/asdasd""), ""View asdas"")";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }

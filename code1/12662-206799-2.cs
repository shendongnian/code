    static class StringExtensions
    {
        public static string Join(this IList<string> value, string separator)
        {
            return string.Join(separator, value.ToArray());
        }
    }
    
    //...
    
    string s = "     1  2    4 5".Split (
        " ".ToCharArray(), 
        StringSplitOptions.RemoveEmptyEntries
        ).Join (" ");

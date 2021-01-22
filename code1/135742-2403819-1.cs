    class Program
        {
            static void Main(string[] args)
            {
                var g = FormatUSPhone("444555222234");
    
            }
    
            public static string FormatUSPhone(string num)
            {
                string results = string.Empty;
    
                if(num.Length == 10)
                {
                    num = num.Replace("(", "").Replace(")", "").Replace("-", "");
                    const string formatPattern = @"(\d{3})(\d{3})(\d{4})";
    
                    results = Regex.Replace(num, formatPattern, "($1) $2-$3");
    
                }else if (num.Length == 12)
                {
                    num = num.Replace("(", "").Replace(")", "").Replace("-", "");
                    const string formatPattern = @"(\d{3})(\d{3})(\d{4})(\d{2})";
    
                    results = Regex.Replace(num, formatPattern, "($1) $2-$3 x$4");
                }
                
                return results;
            }

    public static class StringExtensions{
    
        public static string Prefix(this string str, string prefix){
            return prefix + str;
        }
    
    }
    
    var newString = "Bean".Prefix("Mr. ");

    class Matcher {
        public string Pattern;
        bool IsMatch(string value){
           return Regex.IsMatch(Pattern, value);
        }
    }

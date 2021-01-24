        static void Main(string[] args){
            Regex rx = new Regex(@"\[Ref:(-?[0-9]+)/(-?[0-9]+)/(-?[0-9]+)\]");       
            string text = "This is a string [Ref:1234/823/2]";
            bool matched = rx.IsMatch(text);
        }

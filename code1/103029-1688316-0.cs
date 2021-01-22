    public class Parser : IParser {
    
        private Parser(string s) {
            //Do something with s, probably store it in a field
        }
    
        public static IParser GetNewParser(string s) {
            return new Parser(s);
        }
    }

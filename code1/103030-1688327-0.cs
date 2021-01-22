    public interface IParser<T> where T:IParser<T> {
        T Parse(string s);
    }
    
    public class Parser : IParser<Parser> {
        public Parser Parse(string s) {
            return new Parser(s);
        }
    }

    public class Parser : StringReader {
        public Parser(string s) : base(s) {
        }
        public string NextWord() {
            while ((Peek() >= 0) && (char.IsWhiteSpace((char) Peek())))
                Read();
            StringBuilder sb = new StringBuilder();
            do {
                int next = Read();
                if (next < 0)
                    break;
                char nextChar = (char) next;
                if (char.IsWhiteSpace(nextChar))
                    break;
                sb.Append(nextChar);
            } while (true);
            return sb.ToString();
        }
    }

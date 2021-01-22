    class TokenDefinition
    {
        public readonly Regex Regex;
        public readonly object Token;
        public TokenDefinition(string regex, object token)
        {
            this.Regex = new Regex(string.Format("^{0}$", regex));
            this.Token = token;
        }
    }
    class Lexer : IDisposable
    {
        private readonly TextReader reader;
        private readonly TokenDefinition[] tokenDefinitions;
        private TokenDefinition currentMatch = null;
        private string currentContents = null;
        public Lexer(TextReader reader, TokenDefinition[] tokenDefinitions)
        {
            this.reader = reader;
            this.tokenDefinitions = tokenDefinitions;
        }
        private int countMatches(StringBuilder current)
        {
            int matches = 0;
            string currentString = current.ToString();
            foreach (TokenDefinition t in tokenDefinitions)
            {
                if (t.Regex.IsMatch(currentString))
                {
                    ++matches;
                    
                    currentMatch = t;
                    currentContents = currentString;
                    //Console.WriteLine("'{0}' matches '{1}'", t.Regex, currentString);
                }
            }
            return matches;
        }
        public bool Next()
        {
            StringBuilder current = new StringBuilder();
            currentMatch = null;
            currentContents = null;
            int next = -1;
            while ((next = reader.Peek()) != -1)
            {
                current.Append((char)next);
                // What we've read so far no longer matches any tokens
                // Either that's an error it's time to return that
                // token to the consumer loop.
                if (countMatches(current) == 0)
                    break;
                // Only actually advance the loop if we haven't reached the end
                // of the current token
                reader.Read();
            }
            if (currentMatch != null)
                return true;
            if (next != -1)
                throw new Exception (string.Format("Unable to convert '{0}' into a token", current));
            return false;
        }
        public string TokenContents
        {
            get { return currentContents; }
        }
        public object Token
        {
            get { return currentMatch.Token; }
        }
        public void Dispose()
        {
            reader.Dispose();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string sample = "( one (two 456 --- three \"quoted\" ))";
            TokenDefinition[] defs = new TokenDefinition[]
            {
                new TokenDefinition ("\\s+", "SPACE"),
                new TokenDefinition ("\\w+", "WORD"),
                new TokenDefinition ("[0-9]+", "NUMBER"),
                new TokenDefinition ("\\(", "LEFT"),
                new TokenDefinition ("\"", "QUOTE"),
                new TokenDefinition ("\\)", "RIGHT")
            };
            TextReader r = new StringReader(sample);
            Lexer l = new Lexer(r, defs);
            while (l.Next())
            {
                Console.WriteLine("Token: {0} Contents: {1}", l.Token, l.TokenContents);
            }
            Console.WriteLine("Finished.");
        }
    }

    public class ParsedEmail
    {
        private string _first;
        private string _last;
        private string _name;
        private string _domain;
        public ParsedEmail(string first, string last, string name, string domain)
        {
            _name = name;
            _domain = domain;
            // first.last@domain.com, first_last@domain.com etc. syntax
            char[] chars = { '.', '_', '+', '-' };
            var pos = _name.IndexOfAny(chars);
            if (string.IsNullOrWhiteSpace(_first) && string.IsNullOrWhiteSpace(_last) && pos > -1)
            {
                _first = _name.Substring(0, pos);
                _last = _name.Substring(pos+1);
            }
        }
        public string First
        {
            get { return _first; }
        }
        public string Last
        {
            get { return _last; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string Domain
        {
            get { return _domain; }
        }
        public string Email
        {
            get
            {
                return Name + "@" + Domain;
            }
        }
        public override string ToString()
        {
            return Email;
        }
        public static IEnumerable<ParsedEmail> SplitEmailList(string delimList)
        {
            delimList = delimList.Replace("\"", string.Empty);
            Regex re = new Regex(
                        @"((?<last>\w*), (?<first>\w*) <(?<name>[a-zA-Z_0-9\.\+\-]+)@(?<domain>\w*\.\w*)>)|" +
                        @"((?<first>\w*) (?<last>\w*) <(?<name>[a-zA-Z_0-9\.\+\-]+)@(?<domain>\w*\.\w*)>)|" +
                        @"((?<name>[a-zA-Z_0-9\.\+\-]+)@(?<domain>\w*\.\w*))");
            MatchCollection matches = re.Matches(delimList);
            var parsedEmails =
                       (from Match match in matches
                        select new ParsedEmail(
                                match.Groups["first"].Value,
                                match.Groups["last"].Value,
                                match.Groups["name"].Value,
                                match.Groups["domain"].Value)).ToList();
            return parsedEmails;
        }
    }

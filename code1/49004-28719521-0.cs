    public class TextLink
    {
        #region Properties
        public const string BeginPattern = "((http|https)://)?(www.)?";
        public const string MiddlePattern = @"([a-z0-9\-]*\.)+[a-z]+(:[0-9]+)?";
        public const string EndPattern = @"(/\S*)?";
        public static string Pattern { get { return BeginPattern + MiddlePattern + EndPattern; } }
        public static string ExactPattern { get { return string.Format("^{0}$", Pattern); } }
        public string OriginalInput { get; private set; }
        public bool Valid { get; private set; }
        private bool _isHttps;
        private string _readyLink;
        #endregion
        #region Constructor
        public TextLink(string input)
        {
            this.OriginalInput = input;
            var text = Regex.Replace(input, @"(^\s)|(\s$)", "", RegexOptions.IgnoreCase);
            Valid = Regex.IsMatch(text, ExactPattern);
            if (Valid)
            {
                _isHttps = Regex.IsMatch(text, "^https:", RegexOptions.IgnoreCase);
                // clear begin:
                _readyLink = Regex.Replace(text, BeginPattern, "", RegexOptions.IgnoreCase);
                // HTTPS
                if (_isHttps)
                {
                    _readyLink = "https://www." + _readyLink;
                }
                // Default
                else
                {
                    _readyLink = "http://www." + _readyLink;
                }
            }
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return _readyLink;
        }
        #endregion
    }

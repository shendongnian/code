    class Template
    {
        /// <summary>Map of replacements for characters prefixed with a backward slash</summary>
        private static readonly Dictionary<char, string> EscapeChars
            = new Dictionary<char, string>
            {
                ['r'] = "\r",
                ['n'] = "\n",
                ['\\'] = "\\",
                ['{'] = "{",
            };
        /// <summary>Pre-compiled regular expression used during the rendering process</summary>
        private static readonly Regex RenderExpr = new Regex(@"\\.|{([a-z0-9_.\-]+)}",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>Template string associated with the instance</summary>
        public string TemplateString { get; }
        /// <summary>Create a new instance with the specified template string</summary>
        /// <param name="TemplateString">Template string associated with the instance</param>
        public Template(string TemplateString)
        {
            if (TemplateString == null) {
                throw new ArgumentNullException(nameof(TemplateString));
            }
            this.TemplateString = TemplateString;
        }
        /// <summary>Render the template using the supplied variable values</summary>
        /// <param name="Variables">Variables that can be substituted in the template string</param>
        /// <returns>The rendered template string</returns>
        public string Render(Dictionary<string, object> Variables)
        {
            return Render(this.TemplateString, Variables);
        }
        /// <summary>Render the supplied template string using the supplied variable values</summary>
        /// <param name="TemplateString">The template string to render</param>
        /// <param name="Variables">Variables that can be substituted in the template string</param>
        /// <returns>The rendered template string</returns>
        public static string Render(string TemplateString, Dictionary<string, object> Variables)
        {
            if (TemplateString == null) {
                throw new ArgumentNullException(nameof(TemplateString));
            }
            return RenderExpr.Replace(TemplateString, Match => {
                switch (Match.Value[0]) {
                    case '\\':
                        if (EscapeChars.ContainsKey(Match.Value[1])) {
                            return EscapeChars[Match.Value[1]];
                        }
                        break;
                    case '{':
                        if (Variables.ContainsKey(Match.Groups[1].Value)) {
                            return Variables[Match.Groups[1].Value].ToString();
                        }
                        break;
                }
                return string.Empty;
            });
        }
    }

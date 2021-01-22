    class HtmlSanitizer
    {
        /// <summary>
        /// A regex that matches things that look like a HTML tag after HtmlEncoding to &#DECIMAL; notation. Microsoft AntiXSS 3.0 can be used to preform this. Splits the input so we can get discrete
        /// chunks that start with &#60; and ends with either end of line or &#62;
        /// </summary>
        private static readonly Regex _tags = new Regex(@"&\#60;(?!&\#62;).+?(&\#62;|$)", RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
    
    
        /// <summary>
        /// A regex that will match tags on the whitelist, so we can run them through 
        /// HttpUtility.HtmlDecode
        /// FIXME - Could be improved, since this might decode &#60; etc in the middle of
        /// an a/link tag (i.e. in the text in between the opening and closing tag)
        /// </summary>
        private static readonly Regex _whitelist = new Regex(@"
    ^&\#60;(&\#47;)? (a|b(lockquote)?|code|em|h(1|2|3)|i|li|ol|p(re)?|s(ub|up|trong|trike)?|ul)&\#62;$
    |^&\#60;(b|h)r\s?(&\#47;)?&\#62;$
    |^&\#60;a(?!&\#62;).+?&\#62;$",
                               
    
          RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace |
          RegexOptions.ExplicitCapture | RegexOptions.Compiled);
    
        /// <summary>
        /// HtmlDecode any potentially safe HTML tags from the provided HtmlEncoded HTML input using 
        /// a whitelist based approach, leaving the dangerous tags Encoded HTML tags
        /// </summary>
        public static string Sanitize(string html)
        {
            Match tag;
            MatchCollection tags = _tags.Matches(html);
    
            // iterate through all HTML tags in the input
            for (int i = tags.Count - 1; i > -1; i--)
            {
                tag = tags[i];
                string tagname = tag.Value.ToLowerInvariant();
    
                if (_whitelist.IsMatch(tagname))
                {
                    // If we find a tag on the whitelist, run it through 
                    // HtmlDecode, and re-insert it into the text
                    string safeHtml = HttpUtility.HtmlDecode(tag.Value);
                    html = html.Remove(tag.Index, tag.Length);
                    html = html.Insert(tag.Index, safeHtml);
                }
            }
            return html;
        }
    }

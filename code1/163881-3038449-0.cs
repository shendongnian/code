    /// <summary>
        /// Turns any literal URL references in a block of text into ANCHOR html elements.
        /// </summary>
        public static string ActivateLinksInText(string source)
        {
            source = " " + source + " ";
	        // easier to convert BR's to something more neutral for now.
            source = Regex.Replace(source, "<br>|<br />|<br/>", "\n");
            source = Regex.Replace(source, @"([\s])(www\..*?|http://.*?)([\s])", "$1<a href=\"$2\" target=\"_blank\">$2</a>$3");
            source = Regex.Replace(source, @"href=""www\.", "href=\"http://www.");
            //source = Regex.Replace(source, "\n", "<br />");
            return source.Trim();
        }

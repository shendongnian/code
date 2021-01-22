        /// <summary>
        /// Converts camel case or pascal case to separate words with title case
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToSpacedTitleCase(this string s)
        {
            //http://stackoverflow.com/a/155486/150342
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo
               .ToTitleCase(Regex.Replace(s, 
                            "([a-z](?=[A-Z0-9])|[A-Z](?=[A-Z][a-z]))", "$1 "));
        }

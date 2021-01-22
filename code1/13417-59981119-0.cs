        public static bool IsValidRegexPattern(string pattern, string testText = "", int maxSecondTimeOut = 20)
        {
            if (string.IsNullOrEmpty(pattern)) return false;
            Regex re = new Regex(pattern, RegexOptions.None, new TimeSpan(0, 0, 20));
            try { re.IsMatch(testText); }
            catch{ return false; } //ArgumentException or RegexMatchTimeoutException
            return true;
        }

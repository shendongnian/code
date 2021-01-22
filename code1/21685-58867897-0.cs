        public static string ReplaceWordChars(this string text)
        {
            var s = text;
            // smart single quotes and apostrophe,  single low-9 quotation mark, single high-reversed-9 quotation mark, prime
            s = Regex.Replace(s, "[\u2018\u2019\u201A\u201B\u2032]", "'");
            // smart double quotes, double prime
            s = Regex.Replace(s, "[\u201C\u201D\u201E\u2033]", "\"");
            // ellipsis
            s = Regex.Replace(s, "\u2026", "...");
            // em dashes
            s = Regex.Replace(s, "[\u2013\u2014]", "-");
            // horizontal bar
            s = Regex.Replace(s, "\u2015", "-");
            // double low line
            s = Regex.Replace(s, "\u2017", "-");
            // circumflex
            s = Regex.Replace(s, "\u02C6", "^");
            // open angle bracket
            s = Regex.Replace(s, "\u2039", "<");
            // close angle bracket
            s = Regex.Replace(s, "\u203A", ">");
            // weird tilde and nonblocking space
            s = Regex.Replace(s, "[\u02DC\u00A0]", " ");
            // half
            s = Regex.Replace(s, "[\u00BD]", "1/2");
            // quarter
            s = Regex.Replace(s, "[\u00BC]", "1/4");
            // dot
            s = Regex.Replace(s, "[\u2022]", "*");
            // degrees 
            s = Regex.Replace(s, "[\u00B0]", " degrees");
            return s;
        }
Also a few more replacements in there.

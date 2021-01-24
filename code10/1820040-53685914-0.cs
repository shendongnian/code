        public string GreekToLower(string s)
        {
            string lowerString = s.ToLower();
            // Matches any 'σ' followed by whitespace or end of string
            string returnString = Regex.Replace(lowerString, "σ(\\s+|$)", "ς$1");
            return returnString;
        }

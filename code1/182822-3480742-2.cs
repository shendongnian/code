        private static int ParseInput(string input, int take)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\d+");
            string valueString = string.Empty;
            foreach (System.Text.RegularExpressions.Match match in r.Matches(input))
                valueString += match.Value;
            valueString = valueString.Substring(0, Math.Min(valueString.Length, take));
            return Convert.ToInt32(valueString);
        }

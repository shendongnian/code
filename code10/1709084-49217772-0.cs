    string convert(string input)
        {
            var chars = "0abcdefghijklmnopqrstuvwxyz";
            return string.Join("", 
                               input.Select(
                                   c => char.IsDigit(c) ? 
                                   chars[int.Parse(c.ToString())].ToString() : 
                                   (chars.IndexOf(char.ToLowerInvariant(c))).ToString())
                               );
        }

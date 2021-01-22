    /// <returns>Returns all values inside matches array in a single list</returns>
            public static List<string> GetMatchesArray(String inputString)
            {
                // Matches var matches = new Array( ... );
                Regex r = new Regex("(var matches = new Array\\([^\\)]*\\);)",
                    RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
    
                string arrayString = r.Match(inputString).Groups[0].Value;
    
                List<string> quotedList = new List<string>();
    
                // Matches all the data between the quotes inside var matches
                r = new Regex("\"([^\"]+)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
                for (Match m = r.Match(arrayString); m.Success; m = m.NextMatch())
                {
                    quotedList.Add(m.Groups[1].Value);
                }
    
                return quotedList;
            }

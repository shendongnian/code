            private static IEnumerable<string[]> ReadCsv(string fileName, char delimiter = ';')
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.ASCII);
            // Before splitting on comma for a field array, we have to replace commas witin the fields
            for(int l = 1; l < lines.Length; l++)
            {
                //(\\")(.*?)(\\")
                MatchCollection regexGroup2 = Regex.Matches(lines[l], "(\\\")(.*?)(\\\")");
                if (regexGroup2.Count > 0)
                {
                    for (int g = 0; g < regexGroup2.Count; g++)
                    {
                        lines[l] = lines[l].Replace(regexGroup2[g].Value, regexGroup2[g].Value.Replace(",", "||"));
                    }
                }
            }
            
            // Split
            IEnumerable<string[]> lines_split = lines.Select(a => a.Split(delimiter));
            
            // Reapply commas
            foreach(string[] row in lines_split)
            {
                for(int c = 0; c < row.Length; c++)
                {
                    row[c] = row[c].Replace("||", ",");
                }
            }
            return (lines_split);
        }

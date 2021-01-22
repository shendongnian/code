        /// <summary>
        /// Method used to remove the characters betweeen certain letters in a string. 
        /// </summary>
        /// <param name="rawString"></param>
        /// <param name="enter"></param>
        /// <param name="exit"></param>
        /// <returns></returns>
        public static string RemoveFragmentsBetween(this string rawString, char enter, char exit) 
        {
            if (rawString.Contains(enter) && rawString.Contains(exit))
            {
                int substringStartIndex = rawString.IndexOf(enter) + 1;
                int substringLength = rawString.LastIndexOf(exit) - substringStartIndex;
                if (substringLength > 0)
                {
                    string substring = rawString.Substring(substringStartIndex, substringLength).RemoveFragmentsBetween(enter, exit);
                    if (substring.Length != substringLength) // This would mean that letters have been removed
                    {
                        rawString = rawString.Remove(substringStartIndex, substringLength).Insert(substringStartIndex, substring).Trim();
                    }
                }
                //Source: http://stackoverflow.com/a/1359521/3407324
                Regex regex = new Regex(String.Format("\\{0}.*?\\{1}", enter, exit));
                return new Regex(" +").Replace(regex.Replace(rawString, string.Empty), " ").Trim(); // Removing duplicate and tailing/leading spaces
            }
            else
            {
                return rawString;
            }
        }

        public List<string> Keyword_Search(HtmlNode nSearch)
        {
            var wordFound = new List<string>();
            // cache inner HTML
            string innerHtml = nSearch.InnerHtml;
            string pattern = "(\\b" + string.Join("\\b)|(\\b", _keywordList) + "\\b)";
            Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection myMatches = myRegex.Matches(innerHtml);
            foreach (Match myMatch in myMatches)
            {
                // Group 0 represents the entire match so we skip that one
                for (int i = 1; i < myMatch.Groups.Count; i++)
                {
                    if (myMatch.Groups[i].Success)
                        wordFound.Add(_keywordList[i-1]);
                }
            }
            
            return wordFound;
        }    

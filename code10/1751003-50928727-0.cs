            /// <summary>
            /// Converts select query into equivalent count query
            /// </summary>
            protected string ConvertToCountQuery(string selectQuery)
            {
                if (string.IsNullOrWhiteSpace(selectQuery) || !selectQuery.ToLower().Contains("select"))
                {
                    return string.Empty;
                }
    
                string[] selectParts = Regex.Split(selectQuery, "select", RegexOptions.IgnoreCase).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                string[] fromParts = Regex.Split(selectParts[0], "from", RegexOptions.IgnoreCase).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                selectParts[0] = string.Format("select count(*) from{0}", fromParts[1]);
                return string.Concat(selectParts);
            }

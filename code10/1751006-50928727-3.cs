        /// <summary>
        /// Converts select query into equivalent count query
        /// </summary>
        public static string ConvertToCountQuery(string selectQuery)
    {
        if (string.IsNullOrWhiteSpace(selectQuery) || !selectQuery.ToLower().Contains("select"))
        {
            return string.Empty;
        }
        return string.Concat(
                "select count(*)",
                selectQuery.Substring(selectQuery.ToLower().IndexOf(" from")));
    }

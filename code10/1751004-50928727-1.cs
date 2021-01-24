        /// <summary>
        /// Converts select query into equivalent count query
        /// </summary>
        protected string ConvertToCountQuery(string selectQuery)
        {
            if (string.IsNullOrWhiteSpace(selectQuery) || !selectQuery.ToLower().Contains("select"))
            {
                return string.Empty;
            }
            return string.Concat(
                "select count(*)",
                selectQuery.Substring(selectQuery.IndexOf(" from")));
        }

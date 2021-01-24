        /// <summary>
        /// Converts select query into equivalent count query
        /// </summary>
        public static string ConvertToCountQuery(string selectQuery)
	{
		if (string.IsNullOrWhiteSpace(selectQuery) || !selectQuery.ToLower().Contains(" from"))
		{
			return string.Empty;
		}
		
		string[] fromParts = Regex.Split(selectQuery, " from", RegexOptions.IgnoreCase).Skip(1).ToArray();
		
		return string.Concat("select count(*) from" ,string.Join(" from", fromParts));
	}

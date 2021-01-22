        /// <summary>
        /// Grabs the value from a specific datareader for a list of column names.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="reader">Reader to grab data off of.</param>
		/// <param name="columnNames">Column names that should be interrogated.</param>
		/// <returns>Value from the first correct column name or an exception if none of the columns exist.</returns>
		public static T GetColumnValue<T>(IDataReader reader, params string[] columnNames)
		{
			bool foundValue = false;
			T value = default(T);
			IndexOutOfRangeException lastException = null;
			foreach (string columnName in columnNames)
			{
				try
				{
					int ordinal = reader.GetOrdinal(columnName);
					value = (T)reader.GetValue(ordinal);
					foundValue = true;
				}
				catch (IndexOutOfRangeException ex)
				{
					lastException = ex;
				}
			}
			if (!foundValue)
			{
				string message = string.Format("Column(s) {0} could not be not found.",
					string.Join(", ", columnNames));
				throw new IndexOutOfRangeException(message, lastException);
			}
			return value;
		}

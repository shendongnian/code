    public static class DbExtensions
	{
		public static List<T> ToList<T>(this IDataReader reader, int columnOrdinal = 0)
		{
			var list = new List<T>();
			while(reader.Read())
				list.Add((T)reader[columnOrdinal]);
			return list;
		}
	}

		public static DataTable ToADOTable<T>(this IEnumerable<T> varlist)
		{
			DataTable dtReturn = new DataTable();
			// Use reflection to get property names, to create table
			// column names
			PropertyInfo[] oProps = typeof(T).GetProperties();
			foreach (PropertyInfo pi in oProps)
			{
				Type colType = pi.PropertyType; 
				if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
					colType = colType.GetGenericArguments()[0];
				dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
			}
			foreach (T rec in varlist)
			{
				DataRow dr = dtReturn.NewRow();
				foreach (PropertyInfo pi in oProps)
					dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
			}
			return (dtReturn);
		}

		public static int GetLengthLimit(object obj, string field)
		{
			int dblenint = 0;   // default value = we can't determine the length
			Type type = obj.GetType();
			PropertyInfo prop = type.GetProperty(field);
			// Find the Linq 'Column' attribute
			// e.g. [Column(Storage="_FileName", DbType="NChar(256) NOT NULL", CanBeNull=false)]
			object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
			// Assume there is just one
			if (info.Length == 1)
			{
				ColumnAttribute ca = (ColumnAttribute)info[0];
				string dbtype = ca.DbType;
				if (dbtype.StartsWith("NChar") || dbtype.StartsWith("NVarChar") ||
					dbtype.StartsWith("Char") || dbtype.StartsWith("VarChar")
					)
				{
					int index1 = dbtype.IndexOf("(");
					int index2 = dbtype.IndexOf(")");
					string dblen = dbtype.Substring(index1 + 1, index2 - index1 - 1);
					int.TryParse(dblen, out dblenint);
				}
			}
			return dblenint;
		}
		public static bool CanBeNull(object obj, string field)
		{
			bool canBeNull = false;
			Type type = obj.GetType();
			PropertyInfo prop = type.GetProperty(field); 
			object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true); 
			if (info.Length == 1)
			{
				ColumnAttribute ca = (ColumnAttribute)info[0];
				 canBeNull = ca.CanBeNull; 
			}
			return canBeNull;
		}

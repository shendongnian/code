		public static IDbDataAdapter GetDataAdapter (Database db)
		{
			switch (db)
			{
				default:
				case "MsSql":
					return new SqlDataAdapter ();
				case "MySql"
					return new MySqlDataAdapter ();
			}
		}
		public static IDbCommand GetCommand (Database db)
		{
			switch (db)
			{
				default:
				case "MsSql":
					return new SqlCommand ();
				case "MySql"
					return new MySqlCommand ();
			}
		}

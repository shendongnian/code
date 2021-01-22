	private static void LogSQL(SqlCommand cmd)
		{
			string query = cmd.CommandText;
			
			foreach (SqlParameter prm in cmd.Parameters)
			{
				switch (prm.SqlDbType)
				{
					case SqlDbType.Bit:
						int boolToInt = (bool)prm.Value ? 1 : 0;
						query = query.Replace(prm.ParameterName, string.Format("{0}", (bool)prm.Value ? 1 : 0));
						break;
					case SqlDbType.Int:
						query = query.Replace(prm.ParameterName, string.Format("{0}", prm.Value));
						break;
					case SqlDbType.VarChar:
						query = query.Replace(prm.ParameterName, string.Format("'{0}'", prm.Value));
						break;
					default:
						query = query.Replace(prm.ParameterName, string.Format("'{0}'", prm.Value));
						break;
				}
			}
            // the following is my how I write to my log - your use will vary
			logger.Debug("{0}", query);
			return;
		}
Now I can log the SQL just before I execute it:
LogSQL(queryCmd)
queryCmd.ExecuteNonQuery()
`

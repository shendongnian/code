		static public void AddSampleData(String name)
		{
			String CreateScript = GetScript(String.Format("SampleData_{0}", name));
			IDbConnection MyConnection = null;
			try
			{
				IDbConnection MyConnection = GetConnection();
				MyConnection.Open();
				IDbCommand MyCommand = MyConnection.CreateCommand();
				foreach (String SqlScriptLine in CreateScript.Split(';'))
				{
					String CleanedString = SqlScriptLine.Replace(";", "").Trim();
					if (CleanedString.Length == 0)
						continue;
					MyCommand.CommandText = CleanedString;
					int Result = MyCommand.ExecuteNonQuery();
				}
			}
			finally
			{
				if (MyConnection != null
					&& MyConnection.State == ConnectionState.Open)
					MyConnection.Close();
			}
		}

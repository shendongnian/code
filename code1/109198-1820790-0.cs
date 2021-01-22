        public static int DeleteStudentInfo(long studentNum)
		{
			var cmd = new OleDbCommand("DELETE FROM Students WHERE studentID = @studentId");
			cmd.Parameters.Add("@studentId", OleDbType.BigInt).Value = studentNum;
			return CallNonQuery(cmd);
		}
        private static int CallNonQuery(OleDbCommand query)
		{
			int rowsAffected;
			var conn = new OleDbConnection(ConfigSettingsManager.DBConnectionString);
			query.Connection = conn;
			try
			{
				conn.Open();
				rowsAffected = query.ExecuteNonQuery();
			}
			catch (Exception)
			{
				return -1;
			}
			finally
			{
				conn.Close();
			}
			return rowsAffected;
		}

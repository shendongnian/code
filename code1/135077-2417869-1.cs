    	class SqlSyncTriggerHelper
	{
		private const string triggerSql = @"select sys.triggers.name from sys.triggers, sys.objects
			where sys.objects.name='{0}' and sys.objects.type = 'U' and sys.triggers.parent_id = sys.objects.object_id";
		private DbSyncScopeDescription syncScopeDescription;
		public SqlSyncTriggerHelper(DbSyncScopeDescription syncScopeDescription)
		{
			this.syncScopeDescription = syncScopeDescription;
		}
		public void Apply(SqlConnection conn)
		{
			SqlTransaction transaction = null;
			try
			{
				if (conn.State == System.Data.ConnectionState.Closed)
				{
					conn.Open();
				}
				transaction = conn.BeginTransaction();
				foreach (var table in syncScopeDescription.Tables)
				{
					foreach (string trigger in GetTriggers(table.UnquotedLocalName, conn, transaction))
					{
						AlterTrigger(trigger, conn, transaction);
					}
				}
				transaction.Commit();
			}
			catch
			{
				if (transaction != null)
				{
					transaction.Rollback();
				}
				throw;
			}
			finally
			{
				if (transaction != null)
				{
					transaction.Dispose();
				}
				conn.Close();
			}
		}
		private void AlterTrigger(string trigger, SqlConnection conn, SqlTransaction transaction)
		{
			SqlCommand newCmd = new SqlCommand(string.Format("exec sp_helptext '{0}'", trigger), conn, transaction);
			var triggerStringBuilder = new StringBuilder();
			using (var reader = newCmd.ExecuteReader())
			{
				while (reader.Read())
				{
					triggerStringBuilder.Append(reader.GetValue(0) as string);
				}
			}
			var triggerString = triggerStringBuilder.ToString();
			triggerString = triggerString.Replace("CREATE TRIGGER", "ALTER TRIGGER").Replace(" AS\n", " AS\nSET NOCOUNT ON\n") + "\nSET NOCOUNT OFF";
			var alterTriggerCommand = new SqlCommand(triggerString, conn, transaction);
			alterTriggerCommand.ExecuteNonQuery();
		}
		private IEnumerable<string> GetTriggers(string tableName, SqlConnection conn, SqlTransaction transaction)
		{
			var resultList = new List<string>();
			var command = new SqlCommand(string.Format(triggerSql, tableName), conn, transaction);
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					resultList.Add(reader.GetString(0));
				}
			}
			return resultList;
		}
	}

	public void InsertMySql(string connectionString, string command, DataTable data)
	{
	    using (var connection = new MySqlConnection(connectionString))
	    {
	        connection.Open();
			
			using (var transaction = connection.BeginTransaction())
			{
				try
				{
					using (MySqlCommand cmd = new MySqlCommand(command, connection))
			        {
			            cmd.CommandType = CommandType.Text;
						foreach (var row in data.Rows)
						{
							cmd.Parameters.Clear();
				            foreach (var cell in data.Columns)
							{
								cmd.Parameters.AddWithValue($"@{cell.Name}", row[cell]);
							}
			            	cmd.ExecuteNonQuery();
						}
			        }
					transaction.Commit();
				}
				catch 
				{
					transaction.Rollback();
					throw;
				}
			}
	    }
	}

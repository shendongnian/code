	private DateTime _timeout;
	public void ClearDatabase(SqlConnection connection)
	{
		_timeout = DateTime.Now + TimeSpan.FromSeconds(30);
		do
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = "exec sp_MSforeachtable 'DELETE FROM ?'";
			try
			{
				command.ExecuteNonQuery();
				return;
			}
			catch (SqlException)
			{
			}
		} while (!TimeOut());
		if (TimeOut())
			Assert.Fail("Fail to clear DB");
	}
			
	private bool TimeOut()
	{
		return DateTime.Now > _timeout;
	}

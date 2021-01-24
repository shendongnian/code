	public async Task initialiseClasses()
	{
		using (SqliteConnection _db = new SqliteConnection(@"Filename=.\myDb.db"))
		{
			_db.Open();
			string newSQL = "ALTER TABLE DiscordUser ADD Class char";
			using(SqliteCommand command = new SqliteCommand(newSQL, _db))
			{
				command.ExecuteNonSql();
			}
			
			string tempClass = setClass(7);  //temporary input
			newSQL = "UPDATE DiscordUser SET Class = @newClass";
			using(SqliteCommand command = new SqliteCommand(newSQL, _db))
			{
				command.Parameters.Add("@newClass", SqliteType.Text).Value = tempClass;
				command.ExecuteNonSql();
			}
		}
	}

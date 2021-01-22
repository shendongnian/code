	public static void ExecuteSqlScript(string sqlScript)
	{
		using (MyEntities dataModel = new MyEntities())
		{
			// split script on GO commands
			IEnumerable<string> commands = 
				Regex.Split(
					sqlScript, 
					@"^\s*GO\s*$",
					RegexOptions.Multiline | RegexOptions.IgnoreCase);
			foreach (string command in commands)
			{
				if (command.Trim() != string.Empty)
				{
					dataModel.Database.ExecuteSqlCommand(command);
				}
			}              
		}
	}

    using SQLite;
    public string SQLitePath => Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "xxxxx.sqlite");
    try
			{
				using (var db = new SQLiteConnection(SQLitePath) { Trace = IsDebug })
				{
					List<TargetModel> test = db.Table<TargetModel>().Select(p => p).ToList();
					return test;
				}
			}
			catch (Exception ex)
			{
				BusinessLogger.Manage(ex);
				return null;
			}

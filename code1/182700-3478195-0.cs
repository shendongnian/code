    partial class QueriesTableAdapter
	{
		public QueriesTableAdapter(string connectionString)
		{
			Properties.Settings.Default["connectionString"] = connectionString;
		}
    }

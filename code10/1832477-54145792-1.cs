	public partial class DataManager 
	{
		public DataManager()
		{
			db2 = DependencyService.Get<ISQLiteDB2>().GetConnection();
		}
		List<T> RunQuery<T>(string qry) where T: new()
		{
			lock (l)
			{
				try
				{
					T data = db2.Query<T>(qry);
					return data;
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex);
					Console.WriteLine(qry);
					throw;
				}
			}
		}
	}

	public class MySystem
	{
		public string SystemName { get; set; }
		public string Location { get; set; }
		public string Type { get; set; }
	}
	
	
	void Main()
	{
		var t1s = new List<MySystem>()
		{
			new MySystem { SystemName = "Test1", Location = "KO", Type = "1" },
			new MySystem { SystemName = "Test2", Location = "AP", Type = "1" },
			new MySystem { SystemName = "Test3", Location = "MP", Type = "1" },
		};
	
		var t2s = new List<MySystem>()
		{
			new MySystem { SystemName = "Test1", Location = "KO", Type = "2" },
			new MySystem { SystemName = "Test2", Location = "AP", Type = "2" },
		};
	
		var combined = t1s.ZipLongest(t2s);
		
		Parallel.ForEach(combined, pair =>
		{
			var (t1, t2) = pair;
			ProcessType(t1);
			ProcessType(t2);
		});
	}

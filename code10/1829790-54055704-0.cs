      public class KeyValueClass
		{
			public int Age { get; set; }
			public string Name { get; set; }
		}
		private void DoTheJob()
		{
			var myList = new List<KeyValueClass>
			{
				new KeyValueClass {Age = 21, Name = "Carl"},
				new KeyValueClass {Age = 23, Name = "Vladimir"},
				new KeyValueClass {Age = 25, Name = "Bob"},
				new KeyValueClass {Age = 21, Name = "Olivia"},
				new KeyValueClass {Age = 21, Name = "Carl"},
				new KeyValueClass {Age = 30, Name = "Jacob"},
				new KeyValueClass {Age = 23, Name = "Vladimir"},
 			};
			var myDistinctList = myList.GroupBy(x => new { x.Age, x.Name })
				.Select(c => c.First()).ToList();
		}

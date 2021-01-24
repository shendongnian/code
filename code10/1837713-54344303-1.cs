	public static void Run()
	{
		//Data Initilisation
		var data = new[] {
			new DataItem{ model="a" , qty=1},
			new DataItem{ model="a" , qty=41},
			new DataItem{ model="b" , qty=12},
			new DataItem{ model="c" , qty=17},
		};
		var jsonData = JsonConvert.SerializeObject(data);
		// Process
		var jsonObj = JsonConvert.DeserializeObject<List<DataItem>>(jsonData);
		var result = jsonObj.Where(x => !string.IsNullOrWhiteSpace(x.model))
							.GroupBy(x => x.model)
							.Select(x => new { model = x.Key, sum = x.Sum(y => y.qty) })
							.ToList();
	}
	
	public class DataItem
    {
        public int qty { get; set; }
        public string model { get; set; }
    }
	

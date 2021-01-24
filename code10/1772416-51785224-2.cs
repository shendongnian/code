	public class Model
	{
		public int Id { get; set; }    
		public string Donor { get; set; }
		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
		public string Charity { get; set; }
	}
	
	
	string csv =  File.ReadAllText(file);
	
    //skip(1), for hearder
	var lines = csv.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Skip(1);
	List<Model> models = new List<Model>();
	int id=1;
	foreach (var item in lines)
	{
		var values = item.Split(',');
		if(values.Count()!= 4) continue;//error loging
		
		var model = new Model
		{
			Id = id,
			Donor = values[0],
			Date = DateTime.Parse(values[1]),
			Amount = Decimal.Parse(values[2]),
			Charity = values[3]
		};
		models.Add(model);
		
		id++;
	}
	

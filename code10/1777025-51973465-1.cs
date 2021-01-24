    List<AutoMakes> ListOfAutoMakes = new List<AutoMakes>();
    foreach (var item in SQDB.Query("SELECT year, make FROM cars"))
    {
    	ListOfAutoMakes.Add(new AutoMakes()
    	{
    		id = item.id.Trim(),
    		make = item.make.Trim()
    	});
    }
    ViewBag.ListOfAutoMakes = Newtonsoft.Json.JsonConvert.SerializeObject(ListOfAutoMakes);

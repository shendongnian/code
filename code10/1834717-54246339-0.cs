    var hotel = new Results
    {
    	id= "d875e165-4705-459e-8532-fca2ae811ae0",
    	HotelDictionary = new Dictionary<int,Hotels> {
    	[2323]=new Hotels{Id=2323,Name="Sample1"},
    	[1323]=new Hotels{Id=1323,Name="Sample2"},
    	}
    };
    var jsonString = JsonConvert.SerializeObject(hotel,Newtonsoft.Json.Formatting.Indented);

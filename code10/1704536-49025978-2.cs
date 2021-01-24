    Newtonsoft.Json.Linq.JObject cbpcs = pricestopsale.cbPricegroups;
    foreach (var pricegroupInfo in cbpcs.Properties().Select(p => new { p.Value, p.Name }).ToList())
    {
        // read the properties like this
        var value = pricegroupInfo.Value;
        var name = pricegroupInfo.Name;
        
        if(pricegroupInfo.Value.ToObject<string>() == "foo")
	    {
			Console.WriteLine("this is true");
		}
    }

	var json = /* your json here */;
	var payrolls = JArray.Parse(json);
	
	foreach(var payroll in payrolls)
	{
		foreach (var property in payroll.Children<JProperty>().ToArray())
		{
			if (property.Name.StartsWith("Month") && property.Value.Type == JTokenType.Null)
				property.Remove();
		}
	}
	
	json = payrolls.ToString();

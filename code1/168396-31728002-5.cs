    var propBar = dyn.Properties().FirstOrDefault(i=>i.Name == "Bar");
	if(propBar != null) {
		JObject o = (JObject)propBar.First();
		var propBDay = o.Properties().FirstOrDefault (i => i.Name=="BDay");
		if(propBDay != null) {
			DateTime bday = DateTime.Parse(propBDay.Value.ToString());
			Console.WriteLine("birthday=" + bday.ToString("MM/dd/yyyy"));
		}
	}
   
    //or as a one-liner:
    DateTime mybday = DateTime.Parse(((JObject)dyn.Properties().First(i=>i.Name == "Bar").First()).Properties().First(i=>i.Name == "BDay").Value.ToString());

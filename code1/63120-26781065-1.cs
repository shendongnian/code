	var map = new DaysOfWeekToStringsMap();
	
	//using the Keys static property
	foreach(var day in DaysOfWeekToStringsMap.Keys){
		map[day] = day.ToString();
	}
	foreach(var day in DaysOfWeekToStringsMap.Keys){
		Console.WriteLine("map[{0}]={1}",day, map[day]);
	}
	
	// using iterator
	foreach(var value in map){
		Console.WriteLine("map[{0}]={1}",value.Key, value.Value);
	}

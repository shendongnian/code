	var dictionary1= new Dictionary<string, object>();
 	
	dictionary1.Add("label", (object)"PageloadTime");
	dictionary1.Add("time", (object)"1087");	
	var dictionary2= new Dictionary<string, object>()
	{ 
		{"label", (object)"DOMContentLoadedTime"},
		{"time", (object)"494"}
	};
	
	var list = new List<object>(); // this is the structure of result
	list.Add(dictionary1);
	list.Add(dictionary2);	
	list.Dump();

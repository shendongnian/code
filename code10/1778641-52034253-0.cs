	//Depending on what you're dealing with: Dictionary<string, List<string>>
    Dictionary<string, List<object>> dict = new Dictionary<string, List<object>>{
        {"ID", new List<object>{"Id1", "Id2"}}, 
        {"NAME", new List<object>{"True", "False"}}
    };
		
	foreach(var v in dict.Keys){			
		Console.WriteLine($"{v} = {string.Join(",", dict[v])}");
	}
    //Output:
    //ID = Id1,Id2
    //NAME = True,False

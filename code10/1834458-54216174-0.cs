        var foo = new String[] {"ab" , "cd", "ef"} ;
		var bar = new List<string>();
		
		foreach(var item in foo)
        {
			bar.Add(item);
        }
		var barArray = bar.ToArray();
		
		for(int i = 0; i < foo.Length; i++)
		{
			Console.WriteLine(foo[i]);
			Console.WriteLine(barArray[i]);
		}

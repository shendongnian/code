    var lines = File.ReadLines(@"e:\sample.txt");
    var dictionary = new Dictionary<string,int>();
    foreach(var line in lines.Skip(1))
    {
       var values = line.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
    	if(dictionary.TryGetValue(values[0],out var value))
    	{
    	   value +=int.Parse(values[1]);
    	}
    	else
    	{
          dictionary.Add(values[0], int.Parse(values[1]));
    	}
    }

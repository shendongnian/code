    var lines = File.ReadLines(filePath);
    var dictionary = new Dictionary<string,int>();
    foreach(var line in lines.Skip(1))
    {
    		var values = line.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
    		if(!dictionary.ContainsKey(values[0]))
    		{
    			dictionary.Add(values[0],int.Parse(values[1]));
    		}
    		else
    		{
    			
    			dictionary[values[0]] += int.Parse(values[1]);
    		}
    }

    void Main()
    {
    	var strings = new string[] {"name like %name", "name like '%name'", "name like ' %name'", "name like%name"};
    	var regex = new Regex("^name like ?(%\\w+)");
    	foreach (var item in strings)
    	{
    		Console.WriteLine($"string: \"{item}\" matches: {regex.IsMatch(item)} extracted: {(regex.Match(item).Groups.Count > 0 ? regex.Match(item).Groups[1].Value : string.Empty)}");
    	}
        //Output:
        //string: "name like %name" matches: True extracted: %name
        //string: "name like '%name'" matches: False extracted: 
        //string: "name like ' %name'" matches: False extracted: 
        //string: "name like%name" matches: True extracted: %name
    }

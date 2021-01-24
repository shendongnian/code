    var lines = System.IO.File.ReadAllLines(@"C:\temp\Laura.txt",  Encoding.GetEncoding("Windows-1255"));
    var csv = lines.Select(x =>
    {
    	var parts = x.Split('\t');
    	return new Articles()
    	{
    		id = parts[0].Trim(),
    		name = parts[1].Trim(),
    		body = parts[2].Trim(),
    	};
    }).ToList();

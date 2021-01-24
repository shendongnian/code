	foreach (var filePath in new[] { "file1.txt", "file2.txt" })
	foreach (string line in System.IO.File.ReadAllLines(filePath))
	{
		try
		{
			if (string.IsNullOrWhiteSpace(line))
			{
				continue;//Skip empty lines
			}
			string[] entries = line.Split(null);
			if (entries.Length < 2)
			{
				throw new Exception("Ivalid line");
			}
			if (entries.Length > 2)
			{
				throw new Exception("Suspicious line");
			}
			Console.WriteLine(entries[0] + " " + entries[1]);
			//TODO This code doesn't properly handle files where the first column has spaces
		} catch (Exception )
		{
			//It's may best to catch exceptions per line so that one bad line doesn't break the whole import
            //HOWEVER, it may be a good idea to break *the whole* import 
            //if even one line is bad 
            //so that we don't miss data. 
		}
	}

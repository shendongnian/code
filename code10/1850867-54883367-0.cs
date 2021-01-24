    static void Main(string[] args)
    {
    	var zipPath = "Path-To-Your-Zipfile";
    
    	using (var archive = ZipFile.OpenRead(zipPath))
    	{
    		var xmlFile = archive.Entries.FirstOrDefault(e => e.FullName.EndsWith(".xml"));
    
    		if(xmlFile == null)
    			return;
    
    		using (var stream = xmlFile.Open())
    		{
    			using (var reader = new StreamReader(stream))
    			{
    				var fileContents = reader.ReadToEnd();
    			}
    		}
    	}
    }

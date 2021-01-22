    // using System.IO;
    // for ex. if you want to copy files from D:\A\ to D:\B\
    foreach (var f in Directory.GetFiles(@"D:\A\", "*.*", SearchOption.AllDirectories))
    {
    	var fi =  new FileInfo(f);
    	var di = new DirectoryInfo(fi.DirectoryName);
    
    	// you can filter files here
    	if (fi.Name.Contains("FILTER")
        {
    		if (!Directory.Exists(di.FullName.Replace("A", "B"))
    	    {						
    			Directory.CreateDirectory(di.FullName.Replace("A", "B"));			
    			File.Copy(fi.FullName, fi.FullName.Replace("A", "B"));
    		}
    	}
    }

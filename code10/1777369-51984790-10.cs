    List<string> tempList = new List<string>;
    foreach (string entryExt in extensoes)
    {
    	foreach (string entryDir in diretorios)
    	{
    		//	SearchOption.AllDirectories search the directory and sub directorys if necessary
    		// SearchOption.TopDirectoryOnly search only the directory
    		tempList.AddRange(Directory.GetFiles(entryDir, entryExt, SearchOption.AllDirectories));
    	}
    }
    
    // Here would run all the files that it has found and add them into the DataTable
    foreach (string entry in tempList)
    {
    	DataRow row = tableOfPhotos.NewRow();
    	row[0] = Path.GetFileName(entry);
    	row[1] = entry;
    	tableOfPhotos.Rows.Add(row);
    }

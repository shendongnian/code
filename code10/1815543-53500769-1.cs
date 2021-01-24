    static void Main(string[] args)
    {
    	FolderBrowserDialog SelectFolder = new FolderBrowserDialog();
    	String path = @"C:\newpages";
    
    	var root = new XElement("Pages");
    
    	if (SelectFolder.ShowDialog() == DialogResult.OK)
    	{
    		var FilesXML = new DirectoryInfo(SelectFolder.SelectedPath).GetFiles()
				.Where(f => !f.Name.Contains("0"))
				// Note that the index is 0 based, if you want to start with 1 just replace index by index+1 in Page.Nr
				.Select((file, index) => 
					new XElement("Page.id",
						new XAttribute("Page.Nr",index),
						new XAttribute("Pagetitle",file.FullName),
						new XElement("PageContent",
							new XCData(File.ReadAllText(file.FullName))
						)));
			// Here we already have all your XML ready, just need to add it to the root
			
			root.Add(FilesXML);
    	}
    	Console.WriteLine("finished");
    	Console.ReadKey();
    
    	root.Save(Path.ChangeExtension(path, ".xml"));
    
    }

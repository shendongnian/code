    static void Main(string[] args)
    {
    	FolderBrowserDialog SelectFolder = new FolderBrowserDialog();
    	String path = @"C:\newpages";
    
    	XmlDocument doc = new XmlDocument();
    	XmlElement root = doc.CreateElement("Pages");
    
    	if (SelectFolder.ShowDialog() == DialogResult.OK)
    	{
    		// Don't declare txt here, you're overwriting and only using it in a nested loop, declare it as you use it there
    		// var txt = string.Empty;
    		
    		//string[] Files = Directory.GetFiles((SelectFolder.SelectedPath));
    		// Change to getting FileInfos
    		var Files = new DirectoryInfo(SelectFolder.SelectedPath).GetFiles()
    			// Only keep those who don't contain a zero in file name
    			.Where(f=>!f.Name.Contains("0"));
    		int i = 1;
    		foreach (var file in Files)
    		{
    			//String filename = Path.GetFileNameWithoutExtension((path1));
    			
    			// Don't need a StreamReader not a using block, just read the whole file at once with File.ReadAllText
    			//using (StreamReader sr = new StreamReader(path1))
    			//{
    				//txt = sr.ReadToEnd();
    				
    				var txt = File.ReadAllText(file.FullName);
    				XmlElement id = doc.CreateElement("Page.id");
    				id.SetAttribute("Page.Nr", i.ToString());
    				id.SetAttribute("Pagetitle", file.FullName);
    				XmlElement name = doc.CreateElement("PageContent");
    				XmlCDataSection cdata = doc.CreateCDataSection(txt);
    				name.AppendChild(cdata);
    				id.AppendChild(name);  // page id appenndchild         
    				root.AppendChild(id);  // roots appenedchild
    				doc.AppendChild(root); //Main root
    			//}
    			i++;
    		}
    	}
    	Console.WriteLine("finished");
    	Console.ReadKey();
    
    	doc.Save(Path.ChangeExtension(path, ".xml"));
    
    }

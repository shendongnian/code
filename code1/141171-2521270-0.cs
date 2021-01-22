    List<string> mediaExtensions = new List<string>{"mp3", "mp4"};
    List<string> filesFound = new List<string>();
    void DirSearch(string sDir) 
    {
	   foreach (string d in Directory.GetDirectories(sDir)) 
	   {
		foreach (string f in Directory.GetFiles(d, "*.*")) 
		{
            if(mediaExtensions.Contains(Path.GetExtension(f).ToLower()))
		       filesFound.Add(f);
		}
		DirSearch(d);
	   }
    }

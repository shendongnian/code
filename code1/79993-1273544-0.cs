    void DirSearch(string sDir)
    {
    	try
    	{
    		var files = System.IO.Directory.GetFiles(sDir, "*.*", SearchOption.AllDirectories);
    		foreach (string f in files)
    		{
    			string hash = GetMD5HashFromFile(f);
    			Dic_Files.Add(f, hash);
    		}
    	}
    	catch (System.Exception excpt)
    	{
    		Console.WriteLine(excpt.Message);
    	}
    }

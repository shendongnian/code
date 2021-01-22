    static void WriteToFile(string directory, string name)
    {
    	string filename = String.Format("{0}__{1}", DateTime.Now.ToString("yyyy-MM-dd"), name);
    	string path = Path.Combine(directory, filename);
    	using (StreamWriter sw = File.CreateText(path))
    	{
    		sw.WriteLine("This is just a test");
    	}
    }

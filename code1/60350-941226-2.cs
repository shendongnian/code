    static void WriteToFile(string directory, string name)
    {
    	string filename = String.Format("{0:yyyy-MM-dd}__{1}", DateTime.Now, name);
    	string path = Path.Combine(directory, filename);
    	using (StreamWriter sw = File.CreateText(path))
    	{
    		sw.WriteLine("This is just a test");
    	}
    }

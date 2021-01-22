    Action<string> DelPath = null;
    DelPath = p =>
    {
    	Directory.EnumerateFiles(p).ToList().ForEach(File.Delete);
    	Directory.EnumerateDirectories(p).ToList().ForEach(DelPath);
    	Directory.EnumerateDirectories(p).ToList().ForEach(Directory.Delete);
    };
    DelPath(path);

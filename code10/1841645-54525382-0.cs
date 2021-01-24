    string tempPath = Path.GetTempFileName();
    using (var file = File.OpenWrite(tempPath))
    using (var sw = new StreamWriter(file))
    {
	    sw.WriteLine("I am not an assembly");
    }
    Assembly.LoadFile(tempPath);

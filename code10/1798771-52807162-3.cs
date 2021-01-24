    try
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllLines(path, new string[] {"hi"});
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    

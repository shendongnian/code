    public void ProcessDataFromFile(string path)
    {
        var data = string.Join("", System.IO.File.ReadAllLines(path));
        var text= new StringBuilder(data);
        // process data
    }

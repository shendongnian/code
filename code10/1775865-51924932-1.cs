    public void ProcessDataFromFile(string path, IFileReader reader)
    {
        var data = string.Join("", reader.ReadAllLinesFrom(path));
        var text= new StringBuilder(data);
        // process data
    }

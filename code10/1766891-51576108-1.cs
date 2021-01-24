    public List<string> ToList(string filePath)
    {
        // Identifiers used are:
        var valueList = List<string>();
        var fileStream = new StreamReader(filePath);
        string line;
        // Read the file line by line
        while ((line = fileStream.readLine()) != null)
        {
           // Split the line by the deliminator (the line is a single value)
           valueList.Add(line);
        }
    }

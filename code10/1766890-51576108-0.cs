    public List<string> ToList(string filePath, char deliminator=',')
    {
        // Identifiers used are:
        var valueList = List<string>();
        var fileStream = new StreamReader(filePath);
        string line;
        // Read the file line by line
        while ((line = fileStream.readLine()) != null)
        {
           // Split the line by the deliminator
           var splitLine = line.Split(deliminator);
           foreach (string value in splitLine) 
           {
              valueList.Add(value);
           }
        }
    }

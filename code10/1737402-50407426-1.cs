    reactionInfo = new Dictionary<string, List<string>>();
    string line;
    using (var reader = new StreamReader(filePath))
    {
        var lasKey= "";
        while ((line = reader.ReadLine()) != null)
        {
           if (line.Trim().StartsWith("'"))
           {
                List<string> values = new List<string>();
                if(!reactionInfo.ContainsKey(line))
                {
                  reactionInfo.Add(line, new List<string>());
                  lastKey = line;
                }
                else
                {
                  reactionInfo(lastKey)= line.Split(' ').ToList();
                }
            }
         }
    }

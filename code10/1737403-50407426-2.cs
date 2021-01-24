    reactionInfo = new Dictionary<string, List<string>>();
    string line;
    using (var reader = new StreamReader(filePath))
    {
        var lastKey= "";
        while ((line = reader.ReadLine()) != null)
        {
           if (line.Trim().StartsWith("'"))
           {
                
                if(!reactionInfo.ContainsKey(line))
                {
                  reactionInfo.Add(line, new List<string>());
                  lastKey = line;
                }
                
            }else
                {
                  reactionInfo[lastKey].AddRange(line.Split(' ').ToList());
                }
         }
    }

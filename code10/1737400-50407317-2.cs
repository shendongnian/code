    reactionInfo = new Dictionary<string, List<string>>();
    string line;
    using(StreamReader reader = new StreamReader(filePath))
    {
        while ((line = reader.ReadLine()) != null)
        {
           if (line.Trim().StartsWith("'"))
           {
                List<string> values = new List<string>();
                if(!reactionInfo.TryGetValue(line,out values))
                {
                  var valuesStrings = reader.ReadLine().Split(' ');
                  reactionInfo.Add(line, values.Length > 0 ? new List<string>(new List<string>(valuesStrings)) : new List<string>());
                }
            }
         }
     }

    var lines = content.Split(...);
    string header[] = lines[0].Split(...);
    int numberOfColumns = header.Length;
    var parsedLines = new List<string[]>();
    for (int i = 1; i < lines.Length; i++) {
       var fields = lines[i].Split(...);
       if (fields.Length < numberOfColumns) {
         // combine with next, and increment i
         fields = fields.Union(lines[++i].Split(...));
       }
       parsedLines.Add(fields);
    }
    

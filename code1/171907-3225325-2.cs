    var lines = content.Split(...);
    string header[] = lines[0].Split(...);
    int numberOfColumns = header.Length;
    var parsedLines = new List<string[]>();
    for (int i = 1; i < lines.Length; i++) {
       var line = lines[i];
       while ((fields = line.Split(...)).Length < numberOfColumns) {
         // combine with next, and increment i
         line += lines[++i];
       }
       parsedLines.Add(fields);
    }
    

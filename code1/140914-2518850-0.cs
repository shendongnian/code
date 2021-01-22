    public void ReplaceData(string filePath, string segmentName, 
        int elementPosition, int componentPosition, 
        string oldData, string newData)
    {
        string text = File.ReadAllText(filePath);
        Match match = Regex.Match(text, 
         @"^ISA(?<e>.).{100}(?<c>.)(?<s>.)(\w+.*?\k<s>)*IEA\k<e>\d*\k<e>\d*\k<s>$");
    
        if (!match.Success)
            throw new InvalidOperationException("Not an X12 file");
    
        char elementSeparator = match.Groups["e"].Value[0];
        char componentSeparator = match.Groups["c"].Value[0];
        char segmentTerminator = match.Groups["s"].Value[0];
    
        var segments = text
            .Split(segmentTerminator)
            .Select(s => s.Split(elementSeparator)
                .Select(e => e.Split(componentSeparator)).ToArray())
            .ToArray();
    
        foreach (var segment in segments.Where(s => s[0][0] == segmentName &&
                                  s.Count() > elementPosition &&
                                  s[elementPosition].Count() > componentPosition &&
                                  s[elementPosition][componentPosition] == oldData))
        {
            segment[elementPosition][componentPosition] = newData;
        }
    
        File.WriteAllText(filePath,
            string.Join(segmentTerminator.ToString(), segments
            .Select(e => string.Join(elementSeparator.ToString(), 
                e.Select(c => string.Join(componentSeparator.ToString(), c))
                 .ToArray()))
            .ToArray()));
    }

    var acceptedLines = new HashSet<string>();
    // Populate acceptedLines here
    var query = ReadLines(input).Where(line => acceptedLines.Contains(line))
                                .ToList();
                

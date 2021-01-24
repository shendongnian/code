    List<RHM> data1 = new List<RHM>();
    
    List<string> lines = File.ReadAllLines(filePath).ToList();
    lines.RemoveAt(0);
    int lineNumber = 1; //Here probably should be 2 because you skipping the first line in file with lines.RemoveAt(0);
    foreach (var line in lines)
    {
        string[] entries = line.Split(',');
        RHM nRHM = new RMH 
        {
            Line = lineNumber,
            Name = entries[0],
            Date1 = entries[1],
            Date2 = entries[2]
        };
    
        data1.Add(nRMH);
        lineNumber++;
    }

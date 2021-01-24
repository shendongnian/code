    List<string> filtered = new List<string>();
    foreach (string line in File.ReadLines(filePath))
    {
        bool okToAdd = true;
        foreach (string prefix in ignorePrefixes)
        {
            if (line.StartsWith(prefix))
            {
                okToAdd = false;
                break;         
            }
        }
        if (okToAdd)
        {
            filtered.Add(line);
        }
    }

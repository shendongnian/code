    var deities = new List<Deity>();
    var lines = File.ReadAllLines("Your file.txt");
    for(int i; i < lines.Count; i++)
    {
        var line = lines[i];
        // Get the chunk of lines which represents a deity
        var objectLines = new List<string>();
        while(!string.IsNullOrWhiteSpace(line)) // check if there is some other character for the blank line, use it here if needed
        {
            objectLines.Add(line);
            line = lines[++i];
            continue;
        }
        
        // Create the deity object using that chunk
        var deity = new Deity 
        {
            Name = objectLines[0],
            Origin = objectLines[1], // You might have to remove the prefix Origin :
            Description  = objectLines[2],
        };
        deities.Add(deity);
    }

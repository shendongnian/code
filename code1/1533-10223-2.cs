    var elements = new List<string>();
    var current = new StringBuilder();
    var p = 0;
    
    while (p < internalLine.Length) {
        if (internalLine[p] == '"') {
            p++;
            
            while (internalLine[p] != '"') {
                current.Append(internalLine[p]);
                p++;
            }
            
            // Skip past last ',
            p += 2;
        }
        else {
            while ((p < internalLine.Length) && (internalLine[p] != ',')) {
                current.Append(internalLine[p]);
                p++;
            }
            
            // Skip past ,
            p++;
        }
        
        elements.Add(current.ToString());
        current.Length = 0;
    }

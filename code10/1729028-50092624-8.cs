    string Content = System.IO.File.ReadAllText(FilePath);
    
    string[] Lines = Content.Split('\n');
    
    int LinePosition = 1; // Second line
        
    Lines[LinePosition] = null // Delete selected line
    

    string NewContent = String.Empty; // Content without selected line
    
    // Assembly new content
    foreach(string Line in Lines) NewContent += Line + "\n";
    //Or
    // Assembly new content
    foreach(string Line in Lines) NewContent += String.Format("{0}{1}", Line, "\n");

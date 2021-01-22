    string[] lines = text.Split('\n');
    
    // Find the right line to work with
    int position = 0;
    for (int i = 0; i < lines.Count(); i++)
      if (lines[i].Contains(args[0]))
        position = i - 1;
    
    // Get in range if we had a match in the first line
    if (position == -1)
      position = 0;
    // Adjust the line index so we have 3 lines to work with
    if (position > lines.Count() - 3)
      position = lines.Count() - 3;
        
    string result = String.Join("\n", lines.Skip(position).Take(3).ToArray());

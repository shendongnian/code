    string buffer = string.Empty;
    foreach (string line in File.ReadLines(path2))
    {                    
        if (Regex.IsMatch(line, @"^\d+"))
        {
            if (buffer != string.Empty) 
            {
                File.AppendAllText(path2 + "mfile2.txt", buffer + Environment.NewLine);
                buffer = string.Empty;
            }
            buffer = line;    
        } else {
            buffer += " " + line;
        } 
    }
    if (buffer != string.Empty) 
    {
        File.AppendAllText(path2 + "mfile2.txt", buffer + Environment.NewLine);   
    }

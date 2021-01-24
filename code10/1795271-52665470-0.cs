    string[] allLines = File.ReadAllLines("file.path");
    if(allLines.Length > 0)
    {
       string lastLine = allLines.Last();
       if(lastLine.Length >= 2)
       {
           lastLine = lastLine.Remove(lastLine.Length - 2);
       }
       allLines[allLines.Length - 1] = lastLine;
    }
        
    File.WriteAllLines("file.path", allLines);

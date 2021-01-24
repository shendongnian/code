    var textFile = File.ReadAllLines(); // O(n)
    List<string> fileLines = new List<string>(textFile);
    List<string> fileListToRemove = new List<string>();
    // start with dummy line not in file
    string lastLineWithAsterisk="************";
    int asteriskLocation;
    
    // Sort the file O(n log n)
    fileLines.Sort();
    // iterate backwards. The * will sort directly after the numbers it matches. 
    // O(n)
    for (int i=fileLines.Count()-1; i>=0; i--)
    { 
         asteriskLocation = fileLines[i].IndexOf('*');
         if(asteriskLocation != -1)
             lastLineWithAsterisk =  fileLines[i].SubStr(0,asteriskLocation);
         else
             if(fileLines[i].StartsWith(lastLineWithAsterisk))
                 fileListToRemove.Add(fileLines[i]);
    }

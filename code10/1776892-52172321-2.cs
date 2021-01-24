    var textFile = File.ReadAllLines(); // O(n)
    var outFile = File.Create("C:\\outputfile.txt");
    List<string> fileLines = new List<string>(textFile);
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
         { 
           lastLineWithAsterisk=fileLines[i].SubStr(0,asteriskLocation);
         // Write the * lines
         outFile.WriteLine(fileLines[i]);
         }
         else
             // exclude matching lines
             if(!fileLines[i].StartsWith(lastLineWithAsterisk))
                 outFile.WriteLine(fileLines[i]);
    }
    outFile.Close();
    outFile.Dispose();

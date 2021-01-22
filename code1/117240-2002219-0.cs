    IEnumerable<string> ReadLines()
    {
      // ...
      while ((lineOfLog = logFile.ReadLine()) != null)
      {
        yield return lineOfLog;
      }
    }
    //...
    foreach( var line in ReadLines() )
    {
      ProcessLine(line);
    }

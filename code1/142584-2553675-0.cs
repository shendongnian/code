    bool isOK = false;
    
    foreach (string current in onlythese)
      if (betaFileLine.Contains(current))
      {
         isOK = true;
         break;
      }
    
    if (isOK)
    {
       File.AppendAllText(@"C:\testtestest.txt", betaFileLine);
    }

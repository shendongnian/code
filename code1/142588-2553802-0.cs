    bool match = false;
    
    foreach(String thisString in onlyThese)
    {
        if(betaFileLine.Contains(thisString)
        {
            match = true;
            break;
        }
    }
    
    if(match)
        File.AppendAllText(@"C:\testtestest.txt", betaFileLine);

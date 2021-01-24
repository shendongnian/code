    string[] MatchesFound = new string[keywordRanks.Lines.Length];
    foreach (string currentSourceLine in keywordRanks.Lines)
    {
        string[] SourceLineValue = currentSourceLine.Split(':');
        var match = keywords.Lines.ToList().FindIndex(s => s.Equals(SourceLineValue[0]));
        if (match > -1)
            MatchesFound[match] = currentSourceLine;
    }
    richTextBox1.Lines = MatchesFound.ToArray();
---
         Source     Matches        Result
        -----------------------------------
         aand:1      aand          aand:1
         cnd:5       this one      
         cnds:9      cnds          cnds:9
         fan:2       another one   
         gst:0       cnd           cnd:5
                     fan           fan:2

    var rna = "PhePheLeoArgStopValGlyArgTyrStopPheArgGleHis";
    var pattern = "Stop";
    var keys = new List<string>();
    // the entire rna string is apparently also a key
    keys.Add(rna);
    Match match = Regex.Match(rna, pattern);
    // loop while the pattern is found
    while (match.Success)
    {
        // we want everything after the match
        var from = match.Index + match.Length;
        keys.Add(rna.Substring(from));
        // and then retrieve the next match (if any)
        match = match.NextMatch();
    }

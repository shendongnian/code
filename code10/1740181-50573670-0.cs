    var rna = "PhePheLeoArgStopValGlyArgTyrStopPheArgGleHis";
    var pattern = "Stop";
    var keys = new List<string>();
    keys.Add(rna);
    Match match = Regex.Match(rna, pattern);
    while (match.Success)
    {
        keys.Add(rna.Substring(match.Index + match.Length));
        match = match.NextMatch();
    }

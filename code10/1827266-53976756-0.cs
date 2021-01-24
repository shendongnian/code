    var dic = new Dictionary<string, string>
    {
    	["æ"] = "ae",
    	["ß"] = "ss"
    };
    
    var words = new[] { "encyclopædia", "Archæology", "ARCHÆOLOGY", "Archæology", "Weißbier" };
    var pattern = @"(?i)[^\p{IsBasicLatin}]+";
    
    int x = -1;
    foreach(var word in words)
    {
        // Each match (m.Value) is passed to dictionary 
    	words[++x] = Regex.Replace(word, pattern, m => dic[m.Value.ToLower()]);
    }
    words.ToList().ForEach(WriteLine);
    /*
        Output:
            encyclopaedia
            Archaeology
            ARCHaeOLOGY
            Archaeology
            Weissbier
    */

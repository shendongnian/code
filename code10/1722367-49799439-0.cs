    Dictionary<string,List<string>> values = new Dictionary<string, List<string>>();
    
    var lines = File.ReadAllLines("file.txt");
    var reg = new Regex(@"^\[(\w+)\]$", RegexOptions.Compiled);
    string lastMatch = "";
                
    foreach (var ligne in lines.Where(a=>!String.IsNullOrEmpty(a)))
    {
        var isMatch =  reg.Match(ligne);
        if (isMatch.Success)
        {
            lastMatch = isMatch.Groups[0].Value;
            if(!values.ContainsKey(lastMatch))
                values.Add(lastMatch,new List<string>());
        }else
            values[lastMatch].Add(ligne);
    }

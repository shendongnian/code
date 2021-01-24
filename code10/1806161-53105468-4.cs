    private static string  DoWordReplace()
    {
        //first read in the data
        var fileData = File.ReadAllLines("WordReplace.txt");
        var wordReplacePairs = new List<WordReplace>();
        var lineNo = 1;
        foreach (var item in fileData)
        {
            var pair = item.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            if (pair.Length != 2)
            {
                throw new ApplicationException($"Malformed file, line {lineNo}, data = [{item}] ");
            }
            wordReplacePairs.Add(new WordReplace{Find = pair[0], Replace = pair[1]});
            ++lineNo;
        }
        var longString = "LOL, 123 is a long 999 string yeah, ROFL";
        //now do the replacements
        var buffer = new StringBuilder(longString);
        foreach (var pair in wordReplacePairs)
        {
            buffer.Replace(pair.Find, pair.Replace);
        }
        return buffer.ToString();
    }

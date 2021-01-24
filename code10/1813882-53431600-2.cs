    public string HideName(string str)
    {
        //First split by comma
        var splittedByComma = str.Split(',');
        //Then get separate words from splitted array's first part
        var words = splittedByComma[0].Split(' ');
        //Get names before last name
        var name = words.Skip(1).Take(words.Length - 2);
        //Replace all chars from first names with '*'
        var hiddenPart = string.Join(" ", name.Select(s => new string(s.Select(ch => '*').ToArray())));
        //Compose result
        var result = string.Format("Dear {0} {1}, {2}", hiddenPart, words.Last(), splittedByComma[1].Trim());
        return result;
    }

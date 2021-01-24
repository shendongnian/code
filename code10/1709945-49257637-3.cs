    var restOfData = new List<string>();
    int index = 0;
    foreach (var m in matches.OfType<Match>())
    {
        restOfData.Add(data.Substring(index, m.Index - index));
        index = m.Index + m.Length;
    }
    restOfData.Add(data.Substring(index, data.Length - index));
    // will contain "I have a ", " and a ", "", you might want to remove ""
    restOfData.RemoveAll(string.IsNullOrEmpty);
    

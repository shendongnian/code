    Dictionary<string, item> destDict = new Dictionary<string, item>();
    
    foreach (item curr in items)
    {
        string key = curr.col1 + curr.col2;
        if (!destDict.Keys.Contains(key))
        {
            destDict.Add(key, curr);
        }
        else
        {
            if (destDict[key].date < curr.date)
            {
                destDict[key].date = curr.date;
            }
        }
    }

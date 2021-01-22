    foreach(var item in newInfo)
    {
        int value;
        if (myDict.TryGetValue(item.Name, out value))
        {
            myDict[item.Name] += item.NewInfo;
        }
        else
        {
            myDict[item.Name] = item.NewInfo;
        }
    }

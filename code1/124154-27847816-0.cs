    var indexDict = new Dictionary<string, List<int>>();
    for(int ct = 0; ct < pList.length; ct++)
    {
        var item = pList[ct];
        if (!indexDict.ContainsKey(item.toIndexBy))
        {
            indexDict.Add(item.toIndexBy, new List<int> { ct };
        }
        else
        {
            indexDict[item.toIndexBy].add(ct);
        }
    }

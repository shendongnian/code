    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
    foreach (CenterDetail detail in details)
    {
        List<int> list;
        if (!map.TryGetValue(detail.AreaID, out list)
        {
            map.Add(detail.AreaID, list = new List<int>());
        }
        list.Add(detail.CenterID);
    }
    return map;

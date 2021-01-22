    Dictionary<int, List<CenterDetail>> map = new Dictionary<int, List<CenterDetail>>();
    foreach (CenterDetail detail in details)
    {
        List<CenterDetail> list;
        if (!map.TryGetValue(detail.AreaID, out list)
        {
            list = new List<CenterDetail>();
            map.Add(detail.AreaID, list);
        }
        list.Add(detail);
    }
    return map;

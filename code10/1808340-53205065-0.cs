        var baseItemsDic = new Dictionary<DateTime, List<BaseItem>>();
        foreach(var item in baseItems)
        {
            if (!baseItemsDic.ContainsKey(item.DateUtc))
                baseItemsDic.Add(item.DateUtc, new List<BaseItem>());
            baseItemsDic[item.DateUtc].Add(item);
        }
        var traiderItemsInBase = traiderItems.Where(a => baseItemsDic.ContainsKey(a.DateUtc) && baseItemsDic[a.DateUtc].Any(x => Math.Round(x.Fee, 8) == Math.Round((double)a.Fee * 0.4, 8))).ToList();

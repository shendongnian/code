    dict.SelectMany(x => x.Value)
        .Aggregate(new Dictionary<Item, int>(), (map, item1) => 
            {
                if (map.ContainsKey(item1))
                    map[item1]++;
                else map[item1] = 0;
                return map;
            })
       .Where(y => y.Value > 0)
       .Select(pair =>pair.Key);

    public static List<List<Item>> Map(Item item, List<Item> items)
    {
        var result = new List<List<Item>> { new List<Item> { item } };
        item.Containers.ForEach(container =>
        {
            if (container.Min < 1)
            {
                var visited = new List<int>();
                container.ItemIds.ForEach(id =>
                {
                    var localItem = items.Find(i => i.Id == id);
                    var localItemList = Map(localItem, items);
                    localItemList.Add(new List<Item>());
                    var excludedVisited = result.Where(l => !l.Any(i => visited.Contains(i.Id))).ToList();
                    var remainingNodes = result.Where(l => l.Any(i => visited.Contains(i.Id))).ToList();
                    result = Product(excludedVisited, localItemList).Union(remainingNodes).ToList();
                    visited.Add(id);
                });
            }
            else
            {
                var visited = new List<int>();
                var localResult = new List<List<Item>>();
                container.ItemIds.ForEach(id =>
                {
                    var localItem = items.Find(i => i.Id == id);
                    var localItemList = Map(localItem, items);
                    var excludedVisited = result.Where(l => !l.Any(i => visited.Contains(i.Id))).ToList();
                    var remainingNodes = result.Where(l => l.Any(i => visited.Contains(i.Id))).ToList();
                    localResult.AddRange(Product(excludedVisited, localItemList).Union(remainingNodes).ToList());
                    visited.Add(id);
                });
                result = localResult;
            }
        });
        return result;
    }

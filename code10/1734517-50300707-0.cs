    IDictionary<string,int> count = new Dictionary<string,int>();
    var groups = schedules
        .Select((s, i) => new {
            Item = s
        ,   Index = i
        })
        .GroupBy(p => {
            var name = p.Item.Name;
            int current;
            if (!count.TryGetValue(name, out current)) {
                current = 0;
                count.Add(name, current);
            }
            count[name] = current + 1;
            return new { Name = name, Order = current - p.Index };
        })
        .Select(g => g.ToList())
        .Where(g => g.Count > 1)
        .ToList();

    list1.Concat(list2)
        .ToLookup(p => p.Name)
        .Select(g => g.Aggregate((p1, p2) => new Person 
        {
            Name = p1.Name,
            Value = p1.Value, 
            Change = p2.Value - p1.Value 
        }));

    var lookup = items.ToDictionary(g => g.ID); // items is IEnumerable<IGroup>
    foreach (var item in items.Where(g => g.ParentID != null)) {
        lookup[item.ParentID].Groups.Add(item);
    }
    var parents = items.Where(g => g.ParentID == null);

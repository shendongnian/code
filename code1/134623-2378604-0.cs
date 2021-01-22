    var dict = new Dictionary<Id, Node>();
    foreach (var item in items)
    {
        dict[item.Id] = new Node(item);
    }
    foreach (var item in items)
    {
        dict[item.ParentId].AddChild(dict[item.Id]);
    }

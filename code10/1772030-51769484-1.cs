    foreach (var node in seznamVlaku
        .SelectMany(list => list.ProjizdejiciStanicemi)
        .Where(item => nodes
            .Exists(node => node.ID != item.ID)))
    {
        _nodes.Add(new Node() {Name = node.Key.Jmeno, ID = node.Key.ID, X = node.Key.X, Y = node.Key.Y });
    }

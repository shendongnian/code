    // Build a dictionary of items
    var itemsById = list.ToDictionary(i => i.Id);
    // Build a dictionary of child items of each node; 0 = root
    var childrenById = list.GroupBy(i => i.ParentId).ToDictionary(g => g.Key);
    // Find leaf nodes
    var leaves = list.Where(i => !childrenById.ContainsKey(i.Id));
    // For each leaf, build up a list of parents up to the root then print
    foreach (var leaf in leaves)
    {
        var queue = new LinkedList<Item>();
        var cursor = leaf;
        do
        {
            // NB this will get stuck if there's a cycle in your tree.
            // You might want to guard against this!
            queue.AddFirst(cursor);
        }
        while (itemsById.TryGetValue(cursor.ParentId, out cursor));
        Console.WriteLine(String.Join(":", queue.Select(i => i.Name)));
    }

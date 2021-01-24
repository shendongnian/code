    var nodes = Enumerable.Range(1, 10).Select((id, index) => new Node { Id = Guid.NewGuid(), Name = "Name " + index }).ToList();
    var ordering = nodes.OrderBy(node => node.Id).Select(node => node.Id);
    // By making the ordering list the outer list, all elements will be sorted by this list.
    var join = ordering.Join(nodes, o => o, n => n.Id, (o, n) => n);
    Console.WriteLine("Unordered List");
    foreach (var node in nodes)
    {
        Console.WriteLine($"{node.Name} => {node.Id}");
    }
    Console.WriteLine("Ordering");
    foreach (var order in ordering)
    {
        Console.WriteLine(order);
    }
    Console.WriteLine("Reordered list");
    foreach (var node in join)
    {
        Console.WriteLine($"{node.Name} => {node.Id}");
    }
    Console.ReadKey();

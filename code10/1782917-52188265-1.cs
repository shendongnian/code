    public IEnumerable<SiloNode> Flatten(IEnumerable<SiloNode> nodes)
    {
        var queue = new Queue<SiloNode>();
        foreach (var node in nodes)
        {
            queue.Enqueue(node);
        }         
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
                
            foreach (var child in node.Children)
            {
                 queue.Enqueue(child);
            }
            yield return node;
        }
    }

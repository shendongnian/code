    Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
    Dictionary<Node, Node> π = new Dictionary<Node, Node>();
    
    Queue<Node> worklist = new Queue<Node>();
    
    visited.Add(this, false);
    
    worklist.Enqueue(this);
    
    while (worklist.Count != 0)
    {
        Node node = worklist.Dequeue();
    
        foreach (Node neighbor in node.Neighbors)
        {
            if (!visited.ContainsKey(neighbor))
            {
                visited.Add(neighbor, false);
                π.Add(neighbor, visited);
                worklist.Enqueue(neighbor);
            }
        }
    }

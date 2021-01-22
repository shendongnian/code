    using QuickGraph;
    using QuickGraph.Algorithms;
    
    IVertexAndEdgeListGraph<TVertex, TEdge> graph = ...;
    Func<TEdge, double> edgeCost = e => 1; // constant cost
    TVertex root = ...;
    
    // compute shortest paths
    TryFunc<TVertex, TEdge> tryGetPaths = graph.ShortestPathDijkstra(edgeCost, root);
    
    // query path for given vertices
    TVertex target = ...;
    IEnumerable<TEdge> path;
    if (tryGetPaths(target, out path))
        foreach(var edge in path)
            Console.WriteLine(edge);

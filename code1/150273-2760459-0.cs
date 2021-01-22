    IBidirectionalGraph<int, IEdge<int>> CreateGraph(int vertexCount)
    {
        BidirectionalGraph<int, IEdge<int>> graph = new BidirectionalGraph<int, IEdge<int>>(true);
        for (int i = 0; i < vertexCount; i++)
            graph.AddVertex(i);
        for (int i = 1; i < vertexCount; i++)
            graph.AddEdge(new Edge<int>(i - 1, i));
        return graph;
    }
    
    static public void Main()
    {
        IBidirectionalGraph<int, IEdge<int>> graph = CreateGraph(5);
    
        var dfs = new DepthFirstSearchAlgorithm<int, IEdge<int>>(graph);            
        var observer = new VertexPredecessorRecorderObserver<int, IEdge<int>>();
        using (observer.Attach(dfs)) // attach, detach to dfs events
            dfs.Compute();
        int vertexToFind = 3;
        IEnumerable<IEdge<int>> edges;
        if (observer.TryGetPath(vertexToFind, out edges))
        {
            Console.WriteLine("To get to vertex '" + vertexToFind + "', take the following edges:");
            foreach (IEdge<int> edge in edges)
                Console.WriteLine(edge.Source + " -> " + edge.Target);
        }
    }

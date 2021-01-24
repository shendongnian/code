    public UndirectedGraph<T> ToUndirected()
    {
        var u = new UndirectedGraph<T>();
        foreach (T n1 in nodes)
        {
            u.AddNode(n1);
            foreach (T n2 in Edges(n1))
                u.AddEdge(n1, n2);
        }
        return u;
    }

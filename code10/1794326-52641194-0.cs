    var graph = await Task.Run(()=> {
        var g = new BidirectionalGraph<object, IEdge<object>>();
        foreach (MyItem p in _myItemList)
        {
            g.AddVertex(p);
        }
        foreach (MyItem p in _myItemList)
        {
            foreach (MyItem n in p.CallingList)
            {
                g.AddEdge(new Edge<object>(p, n));
            }
        }
        return g;
    };
    _graph = graph;
     OnPropertyChanged("Graph");

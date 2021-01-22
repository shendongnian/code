    private Dictionary<string, List<string>> _graph
    public void ConstructGraph()
    {
        if (_graph == null) {
            _graph = new Dictionary<string, List<string>>();
            foreach (var rate in rates) {
                if (!_graph.ContainsKey(rate.Base))
                    _graph[rate.Base] = new List<string>();
                if (!_graph.ContainsKey(rate.Target))
                    _graph[rate.Target] = new List<string>();
    
                _graph[rate.Base].Add(rate.Target);
                _graph[rate.Target].Add(rate.Base);
            }
        }
    }

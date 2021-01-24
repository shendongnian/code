    private IEnumerable<EndPoint> Endpoints
    {
        get
        {
            EndPoint[] endpoints = connection.GetEndPoints();
            IServer firstServer = connection.GetServer(endpoints.FirstOrDefault());
    
            return firstServer?.ServerType == ServerType.Cluster ? firstServer.ClusterConfiguration.Nodes.Select(n => n.EndPoint) : endpoints;
        }
    }
    
    private IEnumerable<IServer> Masters => Endpoints
            .Select(e => connection.GetServer(e))
            .Where(s => !s.IsSlave);

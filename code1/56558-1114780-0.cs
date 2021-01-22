    List<Connection> connections = GetConnections();
    connections.Sort(); // sorts by Speed
    bandwidth = 100000;
    for (int i = 0; i < connections.Count; i++)
    {
    	Connection cnn = connections[i];
    	cnn.SpeedLimit = bandwidth / (connections.Count - i);
    	bandwidth -= Math.Min(cnn.Speed, cnn.SpeedLimit);
    }
    
    (start with all connections SpeedLimit set to 20000 bytes/sec)
    
    Speed	bandwidth SpeedLimit
    5000	100000	20000
    10000	95000	23750
    20000	85000	28333
    20000	65000	32500
    20000	45000	45000
    

    void _connectionActivityCheck_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        _connectionActivityCheck.Stop();
        try
        {
            List<Guid> connectionsToRemove = new List<Guid>();
            lock (_connections.SyncRoot)
            {
                IncomingConnection conn;
                
                foreach (DictionaryEntry item in _connections)
                {
                    conn = (IncomingConnection)item.Value;
                    if (conn.LastIncomingActivity.HasValue && 
                        DateTime.Now.Subtract(conn.LastIncomingActivity.Value).TotalSeconds > MaximumInactivitySeconds)
                            connectionsToRemove.Add(conn.ConnectionId);
                }
            }
            if (connectionsToRemove.Count > 0)
            {
                int itemsToRemove = connectionsToRemove.Count;
                foreach (Guid item in connectionsToRemove)
                {
                    RemoveConnection(item);
                }
                Context.Current.Logger.LogInfo(_loggerName, 
                    string.Format("{0} connections were closed due to incoming traffic inactivity", itemsToRemove));
            }
        }
        catch (Exception ex)
        {
            Context.Current.Logger.LogFatal(_loggerName, "An error ocurred while checking incoming traffic.", ex);
        }
        finally
        {
            _connectionActivityCheck.Start();
        }
    }
    private void RemoveConnection(Guid connectionId)
    {
        lock (_connections.SyncRoot)
        {
            try
            {
                IncomingConnection conn = _connections[connectionId] as IncomingConnection;
                if (conn != null)
                {
                    try
                    {
                        conn.Dispose();
                    }
                    catch { }
                    _connections.Remove(connectionId);
                }
            }
            catch { }
        }
    }

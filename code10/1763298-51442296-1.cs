    public async  Task<Connection> ConnectAsync()
    {
       Connection readyConnection;
       lock(@lock)
       {
           if (this.liveConnections == null)
           {
               this.liveConnections = new List<Connection>(this.settings.MIN);
           }
           readyConnection = this.liveConnections.FirstOrDefault(x => !x.IsUsed);
       }
       if (readyConnection == null)
       {
           readyConnection = await CreateConnectionAsync(settings);
           lock(@lock)
           {
                this.liveConnections.Add(readyConnection);
           }
       }
       return readyConnection;
    }

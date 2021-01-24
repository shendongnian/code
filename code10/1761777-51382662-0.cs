    static HashSet<string> CurrentConnections = new HashSet<string>();
        public override Task OnConnected()
        {
            var id = Context.ConnectionId;
            CurrentConnections.Add(id);
            return base.OnConnected();
        }
        public Task SendAllClientsMessage()
        {
            foreach (var activeConnection in GetAllActiveConnections())
            {
                Clients.Client(activeConnection).SendMessageAsync("Hi");
            }
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var connection = CurrentConnections.FirstOrDefault(x => x == Context.ConnectionId);
            if (connection != null)
            {
                CurrentConnections.Remove(connection);
            }
            return base.OnDisconnected(stopCalled);
        }
        //return list of all active connections
        public List<string> GetAllActiveConnections()
        {
            return CurrentConnections.ToList();
        }

    public IList<T> GetClientsByListofID<T>(IList<int> ids) where T : Client
    {
        IList<T> clients = new List<T>();
        clients.Add(new Client(3));
        // ...
    }

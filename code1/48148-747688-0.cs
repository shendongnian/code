        interface IClient
        {
            int Id { get; set; }
        }
        class Client : IClient
        {
            public int Id { get; set; }
            public Client() { }
        }
        // ...
        public IList<T> GetClientsByListofID<T>(IList<int> ids) where T : IClient, new()
        {
            IList<T> clients = new List<T>();
            clients.Add(new T() { Id = 3 });
            // ...
            return clients;
        }

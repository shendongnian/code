        public class Client
        {
            public string Name { get; set; }
            protected Client()
            {
            }
            public static Client Clone(Client copiedClient)
            {
                return new Client
                {
                    Name = copiedClient.Name
                };
            }
        }
        public class Shop
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public ICollection<Client> Clients { get; set; }
            public static Shop Clone(Shop copiedShop, string newAddress, ICollection<Client> clients)
            {
                var copiedClients = new List<Client>();
                foreach (var client in copiedShop.Clients)
                {
                    copiedClients.Add(Client.Clone(client));
                }
                return new Shop
                {
                    Name = copiedShop.Name,
                    Address = newAddress,
                    Clients = copiedClients
                };
            }
        }

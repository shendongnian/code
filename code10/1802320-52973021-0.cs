     protected override void Seed(MR_TrackTrace.Models.ApplicationDbContext context)
            {
    
                var clients = new List<Client>
                {
                    new Client { Name = "John" },
                    new Client { Name = "Mary" },
                    new Client { Name = "Philip" }
                };
    
                clients.ForEach(s => context.Clients.AddOrUpdate(p => p.Name, s));
    
                context.SaveChanges();
                var addresses = new List<Address>
                {
                    new Address { StreetName = "something", ClientId = context.Clients.FirstOrDefault(s => s.Name == "John").ClientId },
                    new Address { StreetName = "other", ClientId = context.Clients.FirstOrDefault(s => s.Name == "Philip").ClientId },
                    new Address { StreetName = "another", ClientId = context.Clients.FirstOrDefault(s => s.Name == "Mary").ClientId }
                };
    
                addresses.ForEach(s => context.Addresses.AddOrUpdate(p => p.Name, s));
                context.SaveChanges();
            }

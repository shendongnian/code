            List<Client> x = new List<Client>();
            x.Add(new Client() { Name = "A" });
            x.Add(new Client() { Name = "B" });
            x.Add(new Client() { Name = "C" });
            x.Add(new Client() { Name = "D" });
            x.Add(new Client() { Name = "B" });
            var z = x.Where(p => p.Name == "A");
            z = x.Where(p => p.Name == "B");

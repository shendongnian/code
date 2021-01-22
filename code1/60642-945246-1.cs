        Request req = new Request {
            Id = 0, Name = new Name {
                Test = true, FirstName = "Dan", LastName = "Atkinson"
            }
        };
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("x1", "Data/Main");
        ns.Add("x2", "Data/All");
        new XmlSerializer(req.GetType()).Serialize(Console.Out, req,ns);

    var clients = from c in context.Clients 
                  group c by c.City into cities 
                  select new {
                      ID = cities.First().ID,
                      City = cities.Key, 
                      Names = string.Join(",", (from n in cities select n.Name).ToArray()) 
                  };
    
    foreach (var c in clients) {
        Console.WriteLine(string.Format("{0}| {1} ({2})", c.ID, c.City, c.Names));
    }

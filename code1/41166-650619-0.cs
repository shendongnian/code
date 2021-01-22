    string email = "xxx@hotmail.com",
           pw = "xAdxar12s";
    var qry = from client in clientContext.Client
              where client.email == email
                 && client.password == pw
              select client;
    Console.WriteLine(qry.Count());

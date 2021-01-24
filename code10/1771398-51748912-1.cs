    interface IMyInterface
    {
         IDbSet<Client> Clients {get; set;}
         IDbSet<...>  ...
         void SaveChanges();
    }
    class Pms : DbContext, IMyInterface {...}
    class Grms: DbContext, IMyInterface {...}

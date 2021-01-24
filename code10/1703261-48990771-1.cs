    class User
    {
         public int Id {get; set;}
         // a user belongs to exactly one Distributor, using foreign key:
         public int DistributorId {get; set;}
         public virtual Distributor Distributor {get; set;}
         ...
    }

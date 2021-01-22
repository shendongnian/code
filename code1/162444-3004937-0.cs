    public class StoreMap : ClassMap<Store>
    {
      public StoreMap()
      {
        Id(x => x.Id);
        Map(x => x.Name);
        HasMany(x => x.Employee)
          .Inverse()
          .Cascade.All();
        HasMany(x => x.Products)
         .Cascade.All();
      }
    }

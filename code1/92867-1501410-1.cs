    public class CatMap : ClassMap<Cat>
    {
      public CatMap()
      {
        Id(x => x.Id);
        Map(x => x.Name)
          .Length(16)
          .Not.Nullable();
        Map(x => x.Sex);
        References(x => x.Mate);
        HasMany(x => x.Kittens);
      }
    }

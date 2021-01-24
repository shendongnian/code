    public class MyEntityConfiguration : EntityTypeConfiguration<MyEntity>
    {
      public MyEntityConfiguration()
      {
        Map(x => x.MapInheritedProperties());
        ToTable("MyEntities");
      }
    }

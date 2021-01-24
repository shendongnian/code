    public class MyEntityConfiguration : EntityTypeConfiguration<MyEntity>
    {
      public MyEntityConfiguration()
      {
        ToTable("MyEntities");
        Map(x => x.MapInheritedProperties());
      }
    }

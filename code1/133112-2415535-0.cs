    public class ForeignKeyReferenceConvention : IHasManyConvention
    {
      public void Apply(IOneToManyCollectionInstance instance)
      {
        instance.Key.Column("EntityId");
      }
    }

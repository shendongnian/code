    public class ReplenishmentDayTypeConvention : ITypeConvention
    {
      public bool CanHandle(Type type)
      {
        return type == typeof(ReplenishmentDay);
      }
    
      public void AlterMap(IProperty propertyMapping)
      {
        propertyMapping
          .CustomTypeIs<ReplenishmentDayUserType>()
          .TheColumnNameIs("RepOn");
      }
    }

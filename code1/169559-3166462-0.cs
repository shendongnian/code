    public class NorthwindService : DataService<NorthwindEntities>
    {
       public static void InitializeService(IDataServiceConfiguration config)
       {
          config.SetEntitySetAccessRule("*", EntitySetRights.All);
        }
    }

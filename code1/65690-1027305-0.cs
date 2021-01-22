    public static void PrintAllPilots(Type type, string pathToDb)
    {
      ...
      IObjectSet result = db.QueryByExample(type);
    }
    
    PrintAllPilots(typeof(SomeType),somePath);

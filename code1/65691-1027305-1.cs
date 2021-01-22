    public static void PrintAllPilots<T>(string pathToDb)
    {
      ...
      IObjectSet result = db.QueryByExample(typeof(T));
    }
    PrintAllPilots<SomeType>(somePath);

    public static void PrintAllPilots<T>(string pathToDb)
    {
       //...
       var result = db.QueryByExample(typeof(T));
    }

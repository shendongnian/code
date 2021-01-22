    public static void PrintAllPilots(Type classType, string pathToDb)
    {
        IObjectContainer db = Db4oFactory.OpenFile(pathToDb);
        IObjectSet result = db.QueryByExample(classType);
        db.Close();
        ListResult(result);
    }

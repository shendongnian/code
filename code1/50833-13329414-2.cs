    static void DumpDatabase()
    {
        var dbFullPath = Utility.GetDbFullPath(); //your path
        if (File.Exists(dbFullPath))
            return; //whatever your logic is
        File.WriteAllBytes(dbFullPath, Properties.Resources.myDb);
    }

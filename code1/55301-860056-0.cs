    using dao;
    
    DBEngine dbengine = new DBEngine();
    dbengine.OpenDatabase(path);
    Database database = dbengine.Workspaces(0).Databases(0);
    List<string> fieldnames = new List<string>();
    foreach (Field field in database.TableDefs(tableName)) {
        fieldnames.Add(field.Name);
    }

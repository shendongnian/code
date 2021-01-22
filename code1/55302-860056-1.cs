    using dao;
    ...
    DBEngineClass dbengine = new DBEngineClass();
    dbengine.OpenDatabase(path, null, null, null);
    Database database = dbengine.Workspaces[0].Databases[0];
    List<string> fieldnames = new List<string>();
    TableDef tdf = database.TableDefs[tableName];
    for (int i = 0; i < tdf.Fields.Count; i++)
    {
        fieldnames.Add(tdf.Fields[i].Name);
    }
    database.Close();
    dbengine.Workspaces[0].Close();

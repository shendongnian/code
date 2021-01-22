    if (!File.Exists(DB_FILENAME))
    {
        var cnnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DB_FILENAME;
        
        // Use a late bound COM object to create a new catalog. This is so we avoid an interop assembly. 
        var catType = Type.GetTypeFromProgID("ADOX.Catalog");
        object o = Activator.CreateInstance(catType);
        catType.InvokeMember("Create", BindingFlags.InvokeMethod, null, o, new object[] {cnnStr});
    
        OleDbConnection cnn = new OleDbConnection(cnnStr);
        cnn.Open();
        var cmd = cnn.CreateCommand();
        cmd.CommandText = "CREATE TABLE VideoPosition (filename TEXT , pos LONG)";
        cmd.ExecuteNonQuery();
    
    }

    string version = "";
    try
    {
        using (OdbcConnection cn = new OdbcConnection("..."))
        using (OdbcCommand cm = cn.CreateCommand())
        {
            cn.Open();
            cm.CommandText = "SELECT @@Version";
            version = cm.ExecuteScalar() as string;
        }
    }
    catch (OdbcException) { }
    return version;

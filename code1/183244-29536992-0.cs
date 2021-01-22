     private static DbDataAdapter CreateDataAdapter(DbCommand cmd)
     {
        DbDataAdapter adapter;
    
        /*
         * DbProviderFactories.GetFactory(DbConnection connection) seams buggy 
         * (.NET Framework too old?)
         * this is a workaround
         */
         string name_space = cmd.Connection.GetType().Namespace;
         DbProviderFactory factory = DbProviderFactories.GetFactory(name_space);
         adapter = factory.CreateDataAdapter();
         adapter.SelectCommand = cmd;
         return adapter;
     }

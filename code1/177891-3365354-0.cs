    public bool BuildLocalDatabase(Func<Database, bool> createTables, Action<Database> resetValues)
    {
         // Do initialization
         if (createTables(db))
         {
               resetValues(db);
         }
    }

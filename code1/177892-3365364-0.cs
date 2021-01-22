    public delegate void MyDelegate();
    
    publid bool BuildLocalDatabase(MyDelegate CreateTablesForApp, MyDelegate ResetDatabaseValuesforApp)
    {
       CreateTablesForApp();
       ...
       ResetDatabaseValuesforApp();
    }

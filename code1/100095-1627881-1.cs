    class John 
    {    IDataSource _db;
         public John(IDataSource db) 
         {
            _db = db;
         }
         public void Load()
         {
            _db.Load("John"); // IDataSource can now be either SQL 
            //or hardcoded or what ever much easier to test
         }                  
    }

         public static InsertResponse GetCollection(List<myCollection> omyCollection, int ddl, string lvl)
                { 
         // code
    var count = (string)cmdCount.ExecuteScalar();
       if ( count >1 )
    return new InsertResponse(){status =failure,Message = "Record Already Exists"};
    // code
    
    // similarly after success
    return new InsertResponse(){status =success,Message = "Record Inserted"};
        }

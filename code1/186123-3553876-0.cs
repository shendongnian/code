    class DBWrapper
    {
    
         public DBWrapper()
         {            
         }
         SqlConnection sqlConn = null; 
         public DataTable RunQuery(string Sql)
         {
                 if(sqlConn == null) sqlConn = new SqlConnection("my connection string");
                 .....implementation......               
         }   
         public Dispose()
         {
                if(sqlConn != null)
                       sqlConn.Close();
         }
    
    }

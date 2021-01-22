    class DBBase : IDBBase {
    
        DataTable IDBBase.getDataTableSql(DataTable curTable, IDbCommand cmd) {
             return getDataTableSql(curTable, (SqlCommand)cmd); // of course you should do some type checks
         }
    
         public DataTable getDataTableSql(DataTable curTable, SqlCommand cmd) {
             ...
         }
    }

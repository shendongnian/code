    public class CoolNewTable : DataTable {
       public void FillFromReader(DbDataReader reader) {
           // We want to get the schema information (i.e. columns) from the 
           // DbDataReader and 
           // import it into *this* DataTable, NOT a new one.
           DataTable schema = reader.GetSchemaTable(); 
           //GetSchemaTable() returns a DataTable with the columns we want.
           ImportSchema(this, schema); // <--- how do we do this?
       }
    }

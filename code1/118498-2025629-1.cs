    using System; 
    using System.Data;   // for DataTable, DataSet
    using System.Data.OleDb;  // for ADO.NET OLEDb provider
----------
    void SaveMyDataTable(DataTable datTable) {
    
        string strConnection = "your connection string to Access";
    
        // Make connection.
        OleDbConnection conn = new OleDbConnection(strConnection);
        conn.Open();
    
        try {
            OleDbCommand cmd = conn.CreateCommand();
    
            // Create table in Access.
            cmd.CommandText = "CREATE TABLE SomeTable("
                    + "Field1 int,"
                    + "ThisField varchar(255)"
                    + "ThatField varchar(255)"
                    + ")";
            cmd.ExecuteNonQuery();
    
            /* Insert data from datatable.
             * (You'll have to pull data out of your DataTable row
             *  and use it here.)
             */
    
            cmd.CommandText = "INSERT INTO SomeTable VALUES (1, 'a','b')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO SomeTable VALUES (3, 'd','e')";
            cmd.ExecuteNonQuery();
            //etc... (maybe make a loop over the rows in your DataTable)
    
            conn.Close();
        }
        finally {
            conn.Close();
        }
    
    }

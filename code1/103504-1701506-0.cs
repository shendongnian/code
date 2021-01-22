    OracleCommand command = null;  
    OracleDataReader dataReader = null;  
    
    string sql = "select * from TEST_TABLE where COLUMN_1 IS NULL"
    
    try  
    {  
        OracleConnection connection = (OracleConnection) dbConnection;  
        command = new OracleCommand( sql, connection );  
    
        dataReader = command.ExecuteReader( );
    
        int recordCount = 0;
        while( dataReader.Read( ) == true )
        {
            recordCount++;
        }
    
        Console.WriteLine( "Count = " + recordCount ); // is 0
    }

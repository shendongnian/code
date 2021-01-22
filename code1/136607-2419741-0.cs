    using( var connection = new SqlConnectino( "my connection string" ) ) {
        using( var command = connection.CreateCommand() ) {
            command.CommandText = "SELECT Column1, Column2, Column3 FROM myTable";
    
            connection.Open();
            using( var dataReader = command.ExecuteReader() ) {
                var indexOfColumn1 = dataReader.GetOrdinal( "Column1" );
                var indexOfColumn2 = dataReader.GetOrdinal( "Column2" );
                var indexOfColumn3 = dataReader.GetOrdinal( "Column3" );
    
                while( reader.Read() ) {
                    var value1 = reader.GetValue( indexOfColumn1 );
                    var value2 = reader.GetValue( indexOfColumn2 );
                    var value3 = reader.GetValue( indexOfColumn3 );
    
                    // now, do something what you want
                }
            }
            connection.Close();
        }
    }

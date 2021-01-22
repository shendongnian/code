    Dictionary<string, string> fields = new Dictionary<string, string>();
    OracleDataReader reader = command.ExecuteReader();
    if( reader.HasRows )
    {
        for( int index = 0; index < reader.FieldCount; index ++ )
        {
            fields[ reader.GetName( index ) ] = reader.GetString( index );
        }    
    }

    public List<XXX> Load( <<args>> )
    {
        using ( var connection = CreateConnection() )
        using ( var command = Create<<ListXXX>>Command( <<args>>, connection ) )
        {
            connection.Open();
            using ( var reader = command.ExecuteReader() )
                return reader.Cast<IDataRecord>()
                    .Select( x => new XXX( x.GetString( 0 ), x.GetString( 1 ) ) )
                    .ToList();
        }
    }

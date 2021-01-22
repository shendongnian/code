    private static Assembly LoadAssemblyFromFile( String filePath )
    {
        using( Stream stream = File.OpenRead( filePath ) )
        {
            if( !ReferenceEquals( stream, null ) )
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read( assemblyData, 0, assemblyData.Length );
                return Assembly.Load( assemblyData );
            }
        }
        return null;
    }

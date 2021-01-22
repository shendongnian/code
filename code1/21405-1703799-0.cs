    try
    {
        Directory.Delete( path, false );
    }
    catch ( IOException )
    {
        Thread.Sleep( 0 );
        Directory.Delete( path, false );
    }

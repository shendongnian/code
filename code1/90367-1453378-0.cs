    foreach( File f in filesToProcess )
    {
        try
        {
            ProcessFile (f);
            MoveFile (f);
        }
        catch( IOException ex )
        {
            Log ("File could not be processed");
        }
    }

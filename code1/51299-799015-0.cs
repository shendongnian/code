    // extracts [resource] into the the file specified by [path]
    void ExtractResource( string resource, string path )
    {
        Stream stream = GetType().Assembly.GetManifestResourceStream( resource );
        byte[] bytes = new byte[(int)stream.Length];
        stream.Read( bytes, 0, bytes.Length );
        File.WriteAllBytes( path, bytes );
    }
    string exePath = "c:\temp\embedded.exe";
    ExtractResource( "myProj.embedded.exe", exePath );
    // run the exe...
    File.Delete( exePath );

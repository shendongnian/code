    // Get all "*.dll" files from "C:\Windows\assembly".
    string windowsDirectory = Environment.GetEnvironmentVariable( "windir" );
    string assemblyDirectory = Path.Combine( windowsDirectory, "assembly" );
    string[] assemblyFiles = Directory.GetFiles(
      assemblyDirectory, "*.dll", SearchOption.AllDirectories
    );
    
    // Get version of each file (ignoring policy, integration, and design files).
    var versionedFiles =
      from path in assemblyFiles
      let filename = Path.GetFileNameWithoutExtension( path )
      where !filename.StartsWith( "policy" ) 
         && !filename.EndsWith( ".ni" ) 
         && !filename.EndsWith( ".Design" )
      let versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo( path )
      select new { Name = filename, Version = versionInfo.FileVersion };
    
    // Select all 3.5 assemblies.
    var assembliesIn3_5 = versionedFiles
      .Where( file => file.Version.StartsWith( "3.5" ) )
      .OrderBy( file => file.Name );
    
    foreach( var file in assembliesIn3_5 )
      Console.WriteLine( "{0,-50} {1}", file.Name, file.Version );

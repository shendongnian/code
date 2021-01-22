    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    var stream = assembly.GetManifestResourceStream("Resources.yourFile.txt");
    var tempPath = Path.GetTempPath();
    File.Save(stream, tempPath);
    
    // use your tempPath here

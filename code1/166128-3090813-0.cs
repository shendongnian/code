    // canonicalize paths
    var dbFiles = db.allPaths().Select(p => Path.GetFullPath(p));
    var allFiles = Directory.EnumerateFiles(path).Select(p => Path.GetFullPath(p));
    foreach (var file in allFiles.Except(dbFiles)) 
    {
        try {
            File.Delete(file);
        } catch (IOException) {
            // handle exception here
        }
    }

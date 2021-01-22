    // canonicalize paths
    var dbFiles = db.allPaths().Select(Path.GetFullPath);
    var allFiles = Directory.EnumerateFiles(path).Select(Path.GetFullPath);
    foreach (var file in allFiles.Except(dbFiles, StringComparer.OrdinalIgnoreCase))
    {
        try {
            File.Delete(file);
        } catch (IOException) {
            // handle exception here
        }
    }

    // canonicalize paths
    var dbFiles = db.allPaths().Select(Path.GetFullPath);
    var allFiles = Directory.EnumerateFiles(Path.GetFullPath(path))
    foreach (var file in allFiles.Except(dbFiles, StringComparer.OrdinalIgnoreCase))
    {
        try {
            File.Delete(file);
        } catch (IOException) {
            // handle exception here
        }
    }

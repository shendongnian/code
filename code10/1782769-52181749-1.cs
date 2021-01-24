    public override string[] CreateEmptyFiles() {
      // Enumerate required files...
      foreach (var file in Directory.EnumerateFiles(RootDirectory, "*." + FileType)) {
        var newFileDestination = Path.Combine(destinationFolder, Path.GetFileName(file));
    
        // ...and move/copy them
        // File.Copy if you want to copy
        File.Move(file, newFileDestination);
      } 
      
      ...
    }

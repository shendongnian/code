    string dirA = @"Main-Folder\";
    string dirB = @"Main-Folder-Copy\";
    
    string[] files = System.IO.Directory.GetFiles(dirA);
    
    foreach (string s in files) {
        if (System.IO.Path.GetExtension(s).equals(".txt")) {
            System.IO.File.Copy(s, System.IO.Path.Combine(targetPath, fileName), true);
        }
    }

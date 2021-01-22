    System.IO.DirectoryInfo[] subDirs;
    System.IO.DirectoryInfo root;
    // assign the value of your root here
    subDirs = root.GetDirectories();
    Random random = new Random();
    int directory = random.Next(subDirs.Length);
    System.IO.DirectoryInfo randomDirectory = subDirs[directory];
    
    

    System.IO.DirectoryInfo[] subDirs = null;
    System.IO.DirectoryInfo root;
    // assign the value of your root here
    subDirs = root.GetDirectories();
    Random random = new Random();
    int directory = Random.Next(subDirs.length());
    System.IO.DirectoryInfo randomDirectory = subDirs[directory];
    
    

    var files = Directory.GetFiles(path, "*.", SearchOption.AllDirectories);
    
    foreach (string item in files)
    {
        //You can rename by moving the files into their 'new names'. 
        //The names are full paths
        File.Move(oldName, newName);
    }

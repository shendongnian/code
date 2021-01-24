    var i = 0;
    string folderPath = directories[i];
    
    while(i < directories.length)
    {
            bool exists = System.IO.Directory.Exists(folderPath);
    
            if(!exists)
                System.IO.Directory.CreateDirectory(folderPath);
    
            i++;
    }

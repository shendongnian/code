    DriveInfo[] drives = DriveInfo.GetDrives();
                
    foreach (DriveInfo drive in drives)
    {
    double fspc = 0.0;
    double tspc = 0.0;
    double percent = 0.0;
                    
    fspc = drive.TotalFreeSpace;
    tspc = drive.TotalSize;
    percent = (fspc / tspc)*100;
    float num = (float)percent;
    
    Console.WriteLine("Drive:{0} With {1} % free", drive.Name,num);
    Console.WriteLine("Space Reamining:{0}", drive.AvailableFreeSpace);
    Console.WriteLine("Percent Free Space:{0}",percent);
    Console.WriteLine("Space used:{0}", drive.TotalSize);
    Console.WriteLine("Type: {0}", drive.DriveType);
    }

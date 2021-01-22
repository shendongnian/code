    foreach (var drive in DriveInfo.GetDrives())
    {
        double freeSpace = drive.TotalFreeSpace;
        double totalSpace = drive.TotalSize;
        double percentFree = (freeSpace / totalSpace) * 100;
        float num = (float)percent;
    
        Console.WriteLine("Drive:{0} With {1} % free", drive.Name, num);
        Console.WriteLine("Space Remaining:{0}", drive.AvailableFreeSpace);
        Console.WriteLine("Percent Free Space:{0}", percent);
        Console.WriteLine("Space used:{0}", drive.TotalSize);
        Console.WriteLine("Type: {0}", drive.DriveType);
    }

    using System;
    using System.IO;
    //...
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            Console.WriteLine("Drive {0}", d.Name);
            Console.WriteLine("  Free:{0, 15} bytes", d.AvailableFreeSpace);            
        }
    

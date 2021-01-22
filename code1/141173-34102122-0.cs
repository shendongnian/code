     var files = new List<string>();
         //@Stan R. suggested an improvement to handle floppy drives...
         //foreach (DriveInfo d in DriveInfo.GetDrives())
         foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
         {
            files.AddRange(Directory.GetFiles(d.RootDirectory.FullName, "File Name", SearchOption.AllDirectories));
         }

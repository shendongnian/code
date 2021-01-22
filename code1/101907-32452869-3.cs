            DriveInfo[] allDrives = DriveInfo.GetDrives(); 
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true && d.DriveType == DriveType.Fixed)
                {
                    Console.WriteLine("Drive {0}", d.Name);
                    Console.WriteLine("  Drive type: {0}", d.DriveType);   
                }           
            }

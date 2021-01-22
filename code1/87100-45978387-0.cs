    public long AvailableFreeSpace()
    {
       	long longAvailableFreeSpace = 0;
        	try{
        		DriveInfo[] arrayOfDrives = DriveInfo.GetDrives();
        		foreach (var d in arrayOfDrives)
        		{
        			Console.WriteLine("Drive {0}", d.Name);
        			Console.WriteLine("  Drive type: {0}", d.DriveType);
        			if (d.IsReady == true && d.Name == "/data")
        			{
        				Console.WriteLine("Volume label: {0}", d.VolumeLabel);
        				Console.WriteLine("File system: {0}", d.DriveFormat);
        				Console.WriteLine("AvailableFreeSpace for current user:{0, 15} bytes",d.AvailableFreeSpace);
        				Console.WriteLine("TotalFreeSpace {0, 15} bytes",d.TotalFreeSpace);
        				Console.WriteLine("Total size of drive: {0, 15} bytes \n",d.TotalSize);
      					}
                        longAvailableFreeSpaceInMB = d.TotalFreeSpace;
      			}
                }
                catch(Exception ex){
        		ServiceLocator.GetInsightsProvider()?.LogError(ex);
      			}
        			return longAvailableFreeSpace;
     }

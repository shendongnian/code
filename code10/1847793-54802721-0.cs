    var diskSize = 2000 * 1024 * 1024;
    var asVhd = false;
    
    using (var fs = new FileStream(_vhfxFileName, FileMode.OpenOrCreate))
    {
        VirtualDisk destDisk = Disk.InitializeDynamic(fs, Ownership.None, diskSize);
    
        if (asVhd)
        {
            destDisk = DiscUtils.Vhd.Disk.InitializeDynamic(fs, Ownership.None, diskSize);
        }
    
        BiosPartitionTable.Initialize(destDisk, WellKnownPartitionType.WindowsNtfs);
        var volMgr = new VolumeManager(destDisk);
    
        var label = $"ZZZZZZ ({dateStamp})";
    
        using (var destNtfs = NtfsFileSystem.Format(volMgr.GetLogicalVolumes()[0], label, new NtfsFormatOptions()))
        {
            destNtfs.NtfsOptions.ShortNameCreation = ShortFileNameOption.Disabled;
    
    		var destDirectory = Path.GetDirectoryName(@"Some file");
    		destNtfs.CreateDirectory(destDirectory, nfo);
    		
    		using (Stream source = new FileStream(@"Some file2", FileMode.Open, FileAccess.Read))
            {
                var destFileName = @"foo";
                
                using (Stream dest = destNtfs.OpenFile(destFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    
                    source.CopyTo(dest);
                    dest.Flush();
                }
            }
    		//do more stuff here
        }
    
        //commit everything to the stream before closing
        fs.Flush();
    }
    

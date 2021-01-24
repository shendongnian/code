    // You'll need to associate required space with each folder
    public class FolderThing
    {
        public string Name {get; set;}
        public int Size {get; set;}
    }
    // Each drive will need to track available free space
    public class DriveThing
    {
        public string Name {get; set;}
        public int AvailableSpace {get; set;}
    }
    // Collection of folders, populate as required.
    var foldersToAllocate = new List<FolderThing>();
    // Collection of drives, populate as required.
    var drivesToUse = new List<DriveThing>();
    var numberOfDrives = drivesToUse.Count();
    foreach (var f in foldersToAllocate)
    {
        // Track whether space could be allocated ...
        bool spaceFound = false;
        // For loop, to exit early on success.
        for (int i=0; i<numberOfDrives; i++)
        {
            var drive = drivesToUse[i];
            
            if (drive.AvailableSpace > f.Size)
            {
                // do the allocate thing
                // update space used for drive
                spaceFound = true;
                break;
            }
        }
        if (spaceFound == false)
        {
            throw new Exception("Could not find enough free space");
        }
    }

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
    int nextDrive = 0;
    foreach (var f in foldersToAllocate)
    {
        // Track whether space could be allocated ...
        bool spaceFound = false;
        int tryCount = 0;
        // For loop, to exit early on success.
        // Try every available drive once, until space is found.
        for (tryCount=0; tryCount<numberOfDrives; tryCount++)
        {
            var drive = drivesToUse[(tryCount + nextDrive) % numberOfDrives];
            
            if (drive.AvailableSpace > f.Size)
            {
                // do the allocate thing
                // update space used for drive
                spaceFound = true;
                break;
            }
        }
        // Increment to the next drive after the previous one.
        nextDrive = (nextDrive + tryCount + 1) % numberOfDrives;
        if (spaceFound == false)
        {
            throw new Exception("Could not find enough free space");
        }
    }

    var eventWatcher = new EventWatcher();
    eventWatcher.OnRenameOrMove += (filename, oldFilename, process) =>
    {
      Console.WriteLine("File " + oldFilename + " has been moved to " + filename + " by process " + process );
    };
    eventWatcher.Connect();
    eventWatcher.WatchPath("C:\\Users\\MyUser\\*");

    var originalFolder = @"c:\myHugeCollectionOfFiles"; // your folder name here
    var someFolder = Path.Combine(originalFolder, "..", Guid.NewGuid().ToString("N"));
    try
    {
        Directory.Move(originalFolder, someFolder);
        // Use files
        Directory.Move(someFolder, originalFolder);
    }
    catch // TODO: proper exception handling
    {
        // Inform user, take action
    }

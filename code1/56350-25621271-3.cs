    var originalFolder = @"c:\myHugeCollectionOfFiles"; // your folder name here
    var someFolder = Path.Combine(originalFolder, "..", Guid.NewGuid().ToString("N"));
    try
    {
        Directory.Move(originalFolder, someFolder);
        // Use files
    }
    catch // TODO: proper exception handling
    {
        // Inform user, take action
    }
    finally
    {
        Directory.Move(someFolder, originalFolder);
    }

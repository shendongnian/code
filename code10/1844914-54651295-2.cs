    // make sure the read buffer is big enough
    string testReadData = "".PadRight(128);
    int filenumber = VB6FileSystem.FreeFile();
    VB6FileSystem.FileOpen(filenumber, @"c:\temp\test.dat", VB.OpenMode.Random,  RecordLength: 128);
    // Write some test data ....
    VB6FileSystem.FilePut(filenumber, "Testdaten 1", 1, true);
    VB6FileSystem.FilePut(filenumber, "Testdaten 4", 4, true);
    VB6FileSystem.FilePut(filenumber, "Testdaten 14", 14, true);
    // Read some data ...
    VB6FileSystem.FileGet(filenumber, ref testReadData, 14, true);
    VB6FileSystem.FileClose(filenumber);

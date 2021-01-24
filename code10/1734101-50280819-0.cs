    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
    {
        ZipArchiveEntry readmeEntry = archive.CreateEntry("test.dat");
        byte[] someData = {10, 20, 30};
        using (BinaryWriter writer = new BinaryWriter(readmeEntry.Open()))
        {
            writer.Write(someData);
        }
    }

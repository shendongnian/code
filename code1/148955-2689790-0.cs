    using (var stream = File.OpenRead("test.zip"))
    using (var zipStream = new ZipInputStream(stream))
    {
        ZipEntry entry;
        while ((entry = zipStream.GetNextEntry()) != null)
        {
            // entry.IsDirectory, entry.IsFile, ...
            Console.WriteLine(entry.Name);
        }
    }

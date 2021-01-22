    var array = new[] { 1L, 2L, 3L };
    using (var stream = new FileStream("test.bin", FileMode.Create, FileAccess.Write, FileShare.None))
    using (var writer = new BinaryWriter(stream))
    {
        foreach (long item in array)
        {
            writer.Write(item);
        }
    }

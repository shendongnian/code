    var junk = new LinkedList<byte[]>();
    int allocSize = 100 * 1024 * 1024; // 100 MiB
    while (allocSize > 0)
    {
        try
        {
            junk.AddLast(null);
            junk.Last.Value = new byte[allocSize];
        }
        catch (OutOfMemoryException)
        {
            allocSize = (allocSize - 1) / 2;
        }
    }

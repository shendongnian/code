    var items = Enumerable.Range(1, 80).Select(i => new { Id = Guid.NewGuid(), Name = $"Item {i}" }).ToList();
    using (var file = MemoryMappedFile.CreateFromFile(@"D:\data.txt", System.IO.FileMode.OpenOrCreate, "myMap", 4096))
    {
        MemoryMappedViewAccessor accessor = null;
        // Small window size to enforce roll-over for testing.
        var windowSize = 100;
        var absolutePosition = 0;
        var relativePosition = 0;
        try
        {
            accessor = file.CreateViewAccessor(absolutePosition, windowSize, MemoryMappedFileAccess.ReadWrite);
            foreach (var item in items)
            {
                var value = $"{item.Id},{item.Name}{Environment.NewLine}";
                var bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length + relativePosition > windowSize)
                {
                    absolutePosition += relativePosition;
                    relativePosition = 0;
                    accessor.Dispose();
                    accessor = file.CreateViewAccessor(absolutePosition, windowSize, MemoryMappedFileAccess.ReadWrite);
                }
                accessor.WriteArray(relativePosition, bytes, 0, bytes.Length);
                relativePosition += bytes.Length;
            }
        }
        finally
        {
            if (accessor != null)
                accessor.Dispose();
        }
    }

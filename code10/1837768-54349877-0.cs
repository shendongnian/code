    var items = Enumerable.Range(1, 10).Select(i => new { Id = Guid.NewGuid(), Name = $"Item {i}" }).ToList();
    using (var file = MemoryMappedFile.CreateFromFile(@"D:\data.txt", System.IO.FileMode.OpenOrCreate, "myMap", 4096))
    {
        using (var accessor = file.CreateViewAccessor(0, 1024, MemoryMappedFileAccess.ReadWrite))
        {
            var position = 0;
            foreach (var item in items)
            {
                var value = $"{item.Id},{item.Name}{Environment.NewLine}";
                var bytes = Encoding.UTF8.GetBytes(value);
                accessor.WriteArray(position, bytes, 0, bytes.Length);
                position += bytes.Length;
            }
        }
    }

    [Fact]
    public async Task TryDeleteDirectory_FileLocked_DirectoryNotDeletedReturnsFalse()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var subDirectoryPath = Path.Combine(Path.GetTempPath(), "SubDirectory");
        var filePath = Path.Combine(directoryPath, "File.txt");
        try
        {
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory(subDirectoryPath);
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                var result = await TryDeleteDirectory(directoryPath, 3, 30);
                Assert.False(result);
                Assert.True(Directory.Exists(directoryPath));
            }
        }
        finally
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
    }
    [Fact]
    public async Task TryDeleteDirectory_FileLockedThenReleased_DirectoryDeletedReturnsTrue()
    {
        var directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var subDirectoryPath = Path.Combine(Path.GetTempPath(), "SubDirectory");
        var filePath = Path.Combine(directoryPath, "File.txt");
        try
        {
            Directory.CreateDirectory(directoryPath);
            Directory.CreateDirectory(subDirectoryPath);
            Task<bool> task;
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                task = TryDeleteDirectory(directoryPath, 3, 30);
                await Task.Delay(30);
                Assert.True(Directory.Exists(directoryPath));
            }
            var result = await task;
            Assert.True(result);
            Assert.False(Directory.Exists(directoryPath));
        }
        finally
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
    }

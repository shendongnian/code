    // Step 1
    public interface ILogger
    {
        void Log(string message);
    }
    
    // Step 2
    public class Logger : ILogger
    {
        void Log(string message)
        {
            // Implementation here
        }
    }
    
    // Step 3
    public bool LocalFileCompare(FileInfo file1, FileInfo file2, ILogger logger)
    {
        if (file1 == null || file2 == null)
        {
            logger.Log("LocalFileCompare: One or both files are null.");
            return false;
        }
        if (file1.FullName != file2.FullName)
        {
            logger.Log($"LocalFileCompare - file names don't match.");
            return false;
        }
        if (file1.Length != file2.Length)
        {
            logger.Log($"LocalFileCompare - file sizes don't match.");
            return false;
        }
    
        return true;
    }
    
    // Step 4
    // Update your calls to LocalFileCompare()
    
    // Step 5
    // Put this somewhere in the Test project
    public class MockLogger : ILogger
    {
        void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    
    // In your test class
    ILogger mockLogger;
    // In your Test Setup method
    mockLogger = new MockLogger();
    [TestMethod]
    public void LocalFileCompare_File2IsNull_ReturnsFalse()
    {
        var t = new tManager(new tSet());
        FileInfo file1 = new FileInfo(@"C:\Temp\TempFile.txt");
        FileInfo file2 = null;
    
        var result = transferSet.LocalFileCompare(file1, file2, mockLogger);
        Assert.IsFalse(result);
    }

    public interface IFileStorage
    {
        byte[] ReadBinaryFile(string fileName);
        void WriteBinaryFile(string fileName, byte[] fileContents);
    }
    public class LocalFileStorage : IFileStorage { ... }
    public class IsolatedFileStorage : IFileStorage { ... }
    public class DatabaseFileStorage : IFileStorage { ... }

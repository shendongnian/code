    public interface IImageService
    {
        void SaveImage(byte[] bytes);
    }
    
    public interface IImageServiceFactory
    {
        IImageService Create(/*here goes enum, string, connections strings, etc*/);
    }
    
    
    internal sealed class AzureImageService : IImageService {}
    internal sealed class FileSystemImageService : IImageService {}

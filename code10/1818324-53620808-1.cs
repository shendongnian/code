    public interface IFileProvider
    {
        string[] GetFiles(string path);
    }
    public class PhysicalFileProvider : IFileProvider
    {
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }

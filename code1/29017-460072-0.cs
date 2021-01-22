    public interface IReadableFile
    {
        Stream OpenRead();
    }
    
    public interface IRepository
    {
        IEnumerable<IReadableFile> Search(string pattern);
    }

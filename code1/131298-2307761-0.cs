    public interface IChangeSet : IEnumerable<IDirectoryEntry>
    {
        IChangeToken GetToken();
    }
    

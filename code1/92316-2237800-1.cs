    public class ActiveDirectoryObject : IDisposable 
    { 
    private bool disposed; 
    public DirectoryEntry Entry { get; protected set; } 
    
    public ActiveDirectoryObject(DirectoryEntry entry) 
    { 
    Entry = entry; 
    } 
    
    public void CommitChanges() 
    { 
    Entry.CommitChanges(); 
    } 
    
    public void Dispose() 
    { 
    Dispose(true); 
    GC.SuppressFinalize(this); 
    } 
    
    private void Dispose(bool disposing) 
    { 
    if (!this.disposed) 
    { 
    if (disposing) 
    { 
    if (Entry != null) Entry.Dispose(); 
    } 
    disposed = true; 
    } 
    } 
    } 
    
    public class AdUser : ActiveDirectoryObject 
    { 
    public AdUser(DirectoryEntry entry) 
    : base(entry) 
    { 
    } 
    } 

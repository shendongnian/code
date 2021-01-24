    private class VersionInfo : IVersionInfo
    {
        public string Api { get { return "2.0"; } }
    }
    
    public interface IVersionInfo
    {
        string Api { get; }
    }

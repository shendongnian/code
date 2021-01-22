    namespace EntLibUnity.UnitySample
    {
        public class VersionManager : IVersionManager
        {
            private readonly Version _version;
    
            public string Version
            {
                get { return _version.ToString(); }
            }
    
            public VersionManager(Version version)
            {
                _version = version;
            }
        }
    }
    
    namespace EntLibUnity.Infrastructure
    {
        public interface IVersionManager
        {
            string Version { get; }
        }
    }

    // Sealed to stop it being extended
    public sealed class VersionInfo
    {
        // Internal to stop it being instantiated outside the library
        internal VersionInfo()
        {
        }
        
        public readonly string Api = "2.0";
    }

    internal partial class Settings : ISettings
    {
        private static ISettings _setInstance;
        internal static ISettings Get
        {
            get
            {
                return _setInstance = _setInstance  ?? Default;
            }
            set { _setInstance = value; }
        }
    }

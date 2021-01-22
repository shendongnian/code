        public interface ICoreLib
        {
            void SomeMethod();
        }
        public static class CoreLibManager
        {
            private static ICoreLib coreLib;
            private static volatile bool initialized;
            private static readonly object lockObject = new object();
            public static ICoreLib CoreLib
            {
                get
                {
                    Inititialize();
                    return coreLib;
                }
            }
    
            /// <summary>
            /// The inititialize.
            /// </summary>
            private static void Inititialize()
            {
                if (initialized)
                {
                    lock (lockObject)
                    {
                        if (!initialized)
                        {
                            string configFile =  // Fech from common location
                            coreLib = new MyCoreLib(configFile);
                            initialized = true;
                        }
                    }
                }
            }
    
            /// <summary>
            /// The my core lib.
            /// </summary>
            private class MyCoreLib : ICoreLib
            {
                public MyCoreLib(string configPath)
                {
                }
                public void SomeMethod()
                {
                }
            }
        }

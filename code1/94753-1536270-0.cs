    namespace PresentationMode
    {
        /// <summary>
        /// This class is used to get a running log of the number of garbage collections that occur,
        /// when running with logging.
        /// </summary>
        public sealed class GCLog
        {
            #region Construction & Destruction
    
            /// <summary>
            /// Releases unmanaged resources and performs other cleanup operations before the
            /// <see cref="GCLog"/> is reclaimed by garbage collection.
            /// </summary>
            ~GCLog()
            {
                SiAuto.Main.LogMessage("GARBAGE COLLECTED");
                if (!AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
                    new GCLog();
            }
    
            #endregion
    
            #region Public Static Methods
    
            /// <summary>
            /// Registers this instance.
            /// </summary>
            public static void Register()
            {
    #if DEBUG
                if (SiAuto.Si.Enabled)
                    new GCLog();
    #endif
            }
    
            #endregion
        }
    }

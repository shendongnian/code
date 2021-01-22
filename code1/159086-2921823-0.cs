        /// <summary>
        /// The command id to use. This is a thread-safe id, that is unique over the lifetime of the process. It changes
        /// at each access.
        /// </summary>
        internal static int NextCommandId
        {
            get
            {
                return _nextCommandId++;
            }
        }       
        private static int _nextCommandId = 0;

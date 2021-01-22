        public static bool IsDebug
        {
            get
            {
                bool debug;
    #if DEBUG
                debug = false;
    #endif
                return debug;
            }
        }

        public static bool IsDebug
        {
            get
            {
                bool debug;
    #if DEBUG
                debug = true;
    #endif
                return debug;
            }
        }

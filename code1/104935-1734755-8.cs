        public static bool IsDebug
        {
            get
            {
                bool debug = false;
    #if DEBUG
                debug = true;
    #endif
                return debug;
            }
        }

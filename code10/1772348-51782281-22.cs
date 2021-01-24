    Func<bool> IsDebugMode(BuildMode mode)
    {
        bool isDebug() 
        {
            return mode == BuildMode.Debug ? true
                : mode == BuildMode.MemoryProfiling ? true
                : mode == BuildMode.Release ? false
                : throw new Exception(...);
       }
        return isDebug;
    }

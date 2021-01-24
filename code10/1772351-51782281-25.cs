    Lazy<bool> IsDebugMode(BuildMode mode)
    {
        bool isDebug() =>
            mode switch {
                BuildMode.Debug           => true,
                BuildMode.MemoryProfiling => true,
                BuildMode.Release         => false,
                _ => throw new Exception (...)
        };
       return new Lazy<bool>(isDebug);
    }

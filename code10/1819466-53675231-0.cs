    bool IsFullFramework = RuntimeInformation.FrameworkDescription.StartsWith(".NET Framework",
        StringComparison.OrdinalIgnoreCase);
    bool IsNetNative = RuntimeInformation.FrameworkDescription.StartsWith(".NET Native",
        StringComparison.OrdinalIgnoreCase);
    bool IsNetCore = RuntimeInformation.FrameworkDescription.StartsWith(".NET Core", 
        StringComparison.OrdinalIgnoreCase);

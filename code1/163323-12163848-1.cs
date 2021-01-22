    public Int32 GetmaxRequestLength()
    {
        // Set the maximum file size for uploads in bytes.
        var section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
        // return length converted to kbytes or return default value as specified
        return (Int32) Math.Round((decimal)(section != null ? (double)section.MaxRequestLength * 1024 / 1000 : 5.120), 2);
    }

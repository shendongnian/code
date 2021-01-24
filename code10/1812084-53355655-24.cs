    bool criticalProcess = false;
    if (!IsProcessCritical(process.Handle, ref criticalProcess))
    {
        // Could not retrieve process information
    }
    if (criticalProcess)
    {
        // This is a critical process, it should be listed
        // in the "Windows processes" section.
    }

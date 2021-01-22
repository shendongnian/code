        using System;
        using System.Linq;
        using System.IO;
    // ...
        var filePath=@"C:\some_path_to_anything";
        var drives = Environment.GetLogicalDrives();
        if (drives.Any(d => filePath.StartsWith(d)) && filePath.LastIndexOfAny(Path.GetInvalidFileNameChars()) == -1)
        {
        // ok, path is valid and we can proceed
        }

        using System;
        using System.Linq;
        using System.IO;
    // ...
        var filePath=@"C:\some_path_to_anything";
        var drives = Environment.GetLogicalDrives();
        var invalidChars = Path.GetInvalidFileNameChars().Except("/\\").ToArray();
        if (drives.Any(d => filePath.StartsWith(d)) && filePath.LastIndexOfAny(invalidChars) == -1)
        {
        // ok, path is valid and we can proceed
        }

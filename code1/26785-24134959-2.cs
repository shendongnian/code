        using System;
        using System.Linq;
        using System.IO;
    // ...
                var drives = Environment.GetLogicalDrives();
                var invalidChars = Regex.Replace(new string(Path.GetInvalidFileNameChars()), "[\\\\/]", "");
                var drive = drives.FirstOrDefault(d => filePath.StartsWith(d));
                if (drive != null)
                {
                    var fileDirPath = filePath.Substring(drive.Length);
                    if (0 < fileDirPath.Length)
                    {
                        if (fileDirPath.IndexOfAny(invalidChars.ToCharArray()) == -1)
                        {
                            if (Path.Combine(drive, fileDirPath) != drive)
                            {
                                // path correct and we can proceed
                            }
                        }
                    }
                }

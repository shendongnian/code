    public static void DirectoryDeleteLong(string directoryPath)
    {
        var emptyDirectory = new DirectoryInfo(Path.GetTempPath() + "\\TempEmptyDirectory_" + DateTime.UtcNow.ToString("yyyyMMddHmmss"));
        emptyDirectory.Create();
        using (var process = new Process())
        {
            process.StartInfo.FileName = "robocopy.exe";
            process.StartInfo.Arguments = "\"" + emptyDirectory.FullName + "\" \"" + directoryPath + "\" /mir /r:1 /w:2 /np";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
        new DirectoryInfo(directoryPath).Attributes = FileAttributes.Normal;
        Directory.Delete(directoryPath);
        emptyDirectory.Delete();
    }

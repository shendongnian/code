    public string ExtractFileFromTaz (string tazFilePath)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "gunzip",
                Arguments = tazFilePath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return result;
    }

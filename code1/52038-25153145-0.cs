    public void SetSystemTimeZone(string timeZoneId)
    {
        var process = Process.Start(new ProcessStartInfo
        {
            FileName = "tzutil.exe",
            Arguments = "/s \"" + timeZoneId + "\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        if (process != null)
        {
            process.WaitForExit();
            TimeZoneInfo.ClearCachedData();
        }
    }

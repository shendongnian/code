    public static List<string> FindingDataDevice(List<string> selectedDevices, string pathData, DateTime DateStartWeek)
    {
        var dateTime = String.Format("{0:yyMMdd}", DateStartWeek);
        var folders = Directory.GetDirectories(pathData).Where(r => selectedDevices.Any(t => r.Contains(t))).ToList();
        return folders.Select(r => Directory.GetFiles(r, "*-" + dateTime + "*"))
                .Where(f => f.Length > 0)
                .SelectMany(f => f)
                .ToList();
    }

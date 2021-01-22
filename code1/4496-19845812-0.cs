    public void LaunchWebServer(string appWebDir)
    {
        var PortNumber = "1162"; // arbitrary unused port #
        var LocalHostUrl = string.Format("http://localhost:{0}", PortNumber);
        var VirtualPath = "/";
    
    	var exePath = FindLatestWebServer();
    
        var process = new Process
        {
            StartInfo =
            {
                FileName = exePath,
                Arguments = string.Format(
                    "/port:{0} /nodirlist /path:\"{1}\" /virtual:\"{2}\"",
                    PortNumber, appWebDir, VirtualPath),
                CreateNoWindow = true,
                UseShellExecute = false
            }
        };
        process.Start();
    }
    
    private string FindLatestWebServer()
    {
        var exeCandidates = new List<string>
        {
            BuildCandidatePaths(11, true), // vs2012
            BuildCandidatePaths(11, false),
            BuildCandidatePaths(10, true), // vs2010
            BuildCandidatePaths(10, false)
        };
        return exeCandidates.Where(f => File.Exists(f)).FirstOrDefault();
    }
    private string BuildCandidatePaths(int versionNumber, bool isX64)
    {
        return Path.Combine(
            Environment.GetFolderPath(isX64
                ? Environment.SpecialFolder.CommonProgramFiles
                : Environment.SpecialFolder.CommonProgramFilesX86),
            string.Format(
                @"microsoft shared\DevServer\{0}.0\WebDev.WebServer40.EXE",
                versionNumber));
    }

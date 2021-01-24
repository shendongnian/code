    public static void LaunchApplication(string exePath, string arguments, bool waitForExit, bool waitForStart, int waitForStartTimeout)
        {
            ProcessStartInfo thisProcessInfo = new ProcessStartInfo();
            thisProcessInfo.CreateNoWindow = true;
            thisProcessInfo.UseShellExecute = false;
            thisProcessInfo.RedirectStandardOutput = false;
            thisProcessInfo.FileName = exePath;
            thisProcessInfo.Arguments = arguments;
            using(Process thisProcess = Process.Start(thisProcessInfo))
            {
                if(waitForStart)
                    thisProcess.WaitForInputIdle(waitForStartTimeout);
                if(waitForExit)
                    thisProcess.WaitForExit();
            }
        }

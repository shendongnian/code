    static string GetDismPath()
    {
        var windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        var systemDir = Environment.Is64BitOperatingSystem ? "SysWOW64" : "System32";
        var dismExePath = Path.Combine(windowsDir, systemDir, "dism.exe");
        return dismExePath;
    }
    static Process StartDism(string args)
    {
        var proc = new Process
        {
            StartInfo =
            {
                FileName = GetDismPath(),
                Verb = "runas",
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            }
        };
            
        proc.Start();
        return proc;
    }
    static void Cleanup(Process proc)
    {
        Task.Run(async () =>
        {
            proc.StandardInput.Close();
            var buf = new char[0x1000];
            while (await proc.StandardOutput.ReadBlockAsync(buf, 0, buf.Length).ConfigureAwait(false) != 0) { }
            while (await proc.StandardError.ReadBlockAsync(buf, 0, buf.Length).ConfigureAwait(false) != 0) { }
            if (!proc.WaitForExit(5000))
            {
                proc.Kill();
            }
            proc.Dispose();
        });
    }
    static async Task Main(string[] args)
    {
        var dismProc = StartDism("/?");
        
        // do what you want with the output
        var dismOutput = await dismProc.StandardOutput.ReadToEndAsync().ConfigureAwait(false);
        await Console.Out.WriteAsync(dismOutput).ConfigureAwait(false);
        Cleanup(dismProc);
    }

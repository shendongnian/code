    public async Task<TResult> WithDism<TResult>(string args, Func<StreamReader, Task<TResult>> func)
    {
        return await Task.Run(async () =>
        {
            var proc = new Process();
            var windowsDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var systemDir = Environment.Is64BitOperatingSystem ? "SysWOW64" : "System32";
            proc.StartInfo.FileName = Path.Combine(windowsDir, systemDir, "dism.exe");
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = args;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            Console.Error.WriteLine("dism started");
            var result = await func(proc.StandardOutput);
            Console.Error.WriteLine("func finished");
            // discard rest of stdout
            await proc.StandardOutput.ReadToEndAsync();
            proc.WaitForExit();
            return result;
        });
    }

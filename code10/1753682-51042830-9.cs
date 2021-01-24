    static void Main(string[] args)
    {
        var proc = new Process 
        {
            StartInfo = new ProcessStartInfo 
            {
                FileName = "CertUtil.exe",
                Arguments = string.Join(" ", args)
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        }.Start();
        Console.WriteLine(proc.StandardOutput.ReadToEnd());
        Console.WriteLine(proc.StandardError.ReadToEnd());
        proc.WaitForExit();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    };

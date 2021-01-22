    var p = new Process {
        StartInfo = new ProcessStartInfo("php", path) {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    var output = new StringWriter();
    var error = new StringWriter();
    p.OutputDataReceived += (sender, args) => output.WriteLine(args.Data);
    p.ErrorDataReceived += (sender, args) => error.WriteLine(args.Data);
    p.Start();
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    p.WaitForExit();
    if (p.ExitCode != 0) {
        throw new Exception(string.Format(
            "PHP failed with the following output:{0}{1}",
            /* {0} */ Environment.NewLine,
            /* {1} */ error.GetStringBuilder().ToString()));
    }
    var res = output.GetStringBuilder().ToString();
    Console.WriteLine(res);

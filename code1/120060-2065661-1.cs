    var proc = new Process
        {
            StartInfo =
            {
                FileName = "perl",
                WorkingDirectory = HttpRuntime.AppDomainAppPath,
                Arguments = " myscript.pl arg1 arg2",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            }
        };
    proc.Start();
    proc.StandardInput.BaseStream.Write... // feed STDIN
    proc.StandardOutput.Read... // Read program output
    var procStdErr = proc.StandardError.ReadToEnd(); // errors
    proc.StandardError.Close();
    proc.StandardOutput.Close();
    proc.WaitForExit(3000);
    int exitCode = proc.ExitCode;
    proc.Close();

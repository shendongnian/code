    using (Process process = Process.Start("cmd.exe") 
    {
       // `cmd` variable can contain your executable without an `exe` extension
       process.Arguments = String.Format("/C \"{0} {1}\"", cmd, String.Join(" ", args));
       process.UseShellExecute  = false;
       process.RedirectStandardOutput = true;
       process.Start();
       process.WaitForExit();
       output = process.StandardOutput.ReadToEnd();
    }

        System.Diagnostics.ProcessStartInfo psi =
        new System.Diagnostics.ProcessStartInfo(@"ffmpeg.exe");
        psi.Arguments = @"-i movie.avi -vn -acodec pcm_s16le -ar 44100 -ac 1 -f wav -";
        psi.RedirectStandardOutput = true;
        psi.UseShellExecute = false;
        Process proc = Process.Start(psi);
        System.IO.StreamReader myOutput = proc.StandardOutput;
        proc.WaitForExit();
        string output;
        if (proc.HasExited)
        {
            output = myOutput.ReadToEnd();
        }
        MessageBox.Show("Done!");

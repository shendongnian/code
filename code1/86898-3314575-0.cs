    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo = new System.Diagnostics.ProcessStartInfo(ffmpegPath, myParams);
    p.UseShellExecute = false;
    p.RedirectStandardInput = true;
    p.Start();
    p.WaitForExit();

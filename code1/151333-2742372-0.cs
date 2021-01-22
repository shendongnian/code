    System.Diagnostics.ProcessStartInfo psi =
      new System.Diagnostics.ProcessStartInfo(@"XCOPY C:\folder D:\Backup\folder /i");
    psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    psi.UseShellExecute = false;
    System.Diagnostics.Process copyFolders = System.Diagnostics.Process.Start(psi);
    copyFolders.WaitForExit();

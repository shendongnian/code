     System.Diagnostics.ProcessStartInfo psi =
       new System.Diagnostics.ProcessStartInfo(@"program_to_call.exe");
     psi.RedirectStandardOutput = true;
     psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
     psi.UseShellExecute = false;
     System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi); ////
     System.IO.StreamReader myOutput = proc.StandardOutput;
     proc.WaitForExit(2000);
     if (proc.HasExited)
      {
          string output = myOutput.ReadToEnd();
     }

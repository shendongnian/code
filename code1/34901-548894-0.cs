    System.Diagnostics.ProcessStartInfo psi =
    new System.Diagnostics.ProcessStartInfo(@"cleartool");
    psi.RedirectStandardOutput = true;
    psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    psi.Arguments = "descr -fmt \"%Sn\" \"" + yourFilePath + "\"";
    psi.UseShellExecute = false;
    System.Diagnostics.Process monProcess;
    monProcess= System.Diagnostics.Process.Start(psi);
    System.IO.StreamReader myOutput = monProcess.StandardOutput;
    monProcess.WaitForExit();
    if (monProcess.HasExited)
    {
        //la sortie du process est recuperee dans un string
        string output = myOutput.ReadToEnd();
        MessageBox.Show(output);
    }

    // Normal creation and initialization of process - additionally:
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += ProcessOnOutputDataReceived;
    process.Start();
    process.BeginOutputReadLine();

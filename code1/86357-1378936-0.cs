    // Normal creation and initialization of process - additionally:
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += ProcessOnOutputDataReceived;
    process.Start();
    process.BeginOutputReadLine();

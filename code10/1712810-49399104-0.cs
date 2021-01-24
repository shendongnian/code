    ffm.EnableRaisingEvents = true;
    ffm.OutputDataReceived += (s, ea) => { Debug.WriteLine($"STD: {ea.Data}"); };
    ffm.ErrorDataReceived += (s, ea) => { Debug.WriteLine($"ERR: {ea.Data}"); };
    ffm.Start();
    ffm.BeginOutputReadLine();
    ffm.BeginErrorReadLine();

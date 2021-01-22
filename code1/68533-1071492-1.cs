    processObject.StartInfo.RedirectStandardOutput = true;
    processObject.OutputDataReceived += new DataReceivedEventHandler(processObject_OutputDataReceived);
    /* ... */
    processObject.Start();
    processObject.BeginOutputReadLine();

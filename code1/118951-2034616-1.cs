    // process is Process
    process.UseShellExecute = false;
    process.RedirectStandardError = true;
    process.ErrorDataReceived += DataReceived;
    process.Start();
    process.BeginErrorReadLine(); // start asynchronous error read
    .
    .
    .
    process.CancelErrorRead();
    void DataReceived(object sender, DataReceivedEventArgs e) {
        // e.Data is line of redirected standard error
    }

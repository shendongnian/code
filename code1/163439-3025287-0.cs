    var psi = new Process.StartInfo ("gcc", "-gcc -arguments") {
        RedirectStandardError = true,
        RedirectStandardOutput = true,
        UseShellExecute = false,
    };
    var error  = new System.Text.StringBuilder ();
    var output = new System.Text.StringBuilder ();
    
    var p = Process.Start (psi);
    p.EnableRaisingEvents = true;
    p.OutputDataReceived +=
        (object s, DataReceivedEventArgs e) => output.Append (e.Data);
    p.ErrorDataReceived  +=
        (object s, DataReceivedEventArgs e) => output.Append (e.Data);
    
    p.WaitForExit ();

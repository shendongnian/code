    private void StartHiddenConsoleApp( string exePath, string args )
    {
        var psi = new ProcessStartInfo();
    
        psi.Arguments = args;
        psi.CreateNoWindow = false;
        psi.ErrorDialog = false;
        psi.FileName = exePath;
        psi.WindowStyle = ProcessWindowStyle.Hidden;
    
        var p = Process.Start( psi );
    }

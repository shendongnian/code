    [DllImport( "user32.dll" )]
    public static extern bool ShowWindowAsync( HandleRef hWnd, int nCmdShow );
    public const int SW_RESTORE = 9;
    public void SwitchToCurrent() {
      IntPtr hWnd = IntPtr.Zero;
      Process process = Process.GetCurrentProcess();
      Process[] processes = Process.GetProcessesByName( process.ProcessName );
      foreach ( Process _process in processes ) {
        // Get the first instance that is not this instance, has the
        // same process name and was started from the same file name
        // and location. Also check that the process has a valid
        // window handle in this session to filter out other user's
        // processes.
        if ( _process.Id != process.Id &&
          _process.MainModule.FileName == process.MainModule.FileName &&
          _process.MainWindowHandle != IntPtr.Zero ) {
          hWnd = _process.MainWindowHandle;
          ShowWindowAsync( NativeMethods.HRef( hWnd ), SW_RESTORE );
          break;
        }
      }
     }

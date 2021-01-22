    static class Program
    {
        static private SafeFileHandle ConsoleHandle;
        /// <summary>
        /// Initialize the Win32 console for this process.
        /// </summary>
        static private void InitWin32Console()
        {
            if ( !K32.AllocConsole() ) {
                MessageBox.Show( "Cannot allocate console",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            IntPtr handle = K32.CreateFile(
                                 "CONOUT$",                                    // name
                                 K32.GENERIC_WRITE | K32.GENERIC_READ,         // desired access
                                 K32.FILE_SHARE_WRITE | K32.FILE_SHARE_READ,   // share access
                                 null,                                         // no security attributes
                                 K32.OPEN_EXISTING,                            // device already exists
                                 0,                                            // no flags or attributes
                                 IntPtr.Zero );                                // no template file.
            ConsoleHandle = new SafeFileHandle( handle, true );
            if ( ConsoleHandle.IsInvalid ) {
                MessageBox.Show( "Cannot create diagnostic console",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            //
            // Set the console screen buffer and window to a reasonable size
            //  1) set the screen buffer sizse
            //  2) Get the maximum window size (in terms of characters) 
            //  3) set the window to be this size
            //
            const UInt16 conWidth     = 256;
            const UInt16 conHeight    = 5000;
            K32.Coord dwSize = new K32.Coord( conWidth, conHeight );
            if ( !K32.SetConsoleScreenBufferSize( ConsoleHandle.DangerousGetHandle(), dwSize ) ) {
                MessageBox.Show( "Can't get console screen buffer information.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            K32.Console_Screen_Buffer_Info SBInfo = new K32.Console_Screen_Buffer_Info();
            if ( !K32.GetConsoleScreenBufferInfo( ConsoleHandle.DangerousGetHandle(), out SBInfo ) ) {
                MessageBox.Show( "Can't get console screen buffer information.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                return;
            }
            K32.Small_Rect sr; ;
            sr.Left = 0;
            sr.Top = 0;
            sr.Right = 132 - 1;
            sr.Bottom = 51 - 1;
            if ( !K32.SetConsoleWindowInfo( ConsoleHandle.DangerousGetHandle(), true, ref sr ) ) {
                MessageBox.Show( "Can't set console screen buffer information.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            IntPtr conHWND = K32.GetConsoleWindow();
            if ( conHWND == IntPtr.Zero ) {
                MessageBox.Show( "Can't get console window handle.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            if ( !U32.SetForegroundWindow( conHWND ) ) {
                MessageBox.Show( "Can't set console window as foreground.",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );
                return;
            }
            K32.SetConsoleTitle( "Test - Console" );
            Trace.Listeners.Add( new ConsoleTraceListener() );
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitWin32Console();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Main() );
        }
    }

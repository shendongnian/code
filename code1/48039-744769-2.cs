    bool isConsole = true;
    try
    {
        isconsole = Console.CursorLeft >= int.MinValue;
    }
    catch( IOException )
    {
        // Try to attach to parent process's console window
        isConsole = AttachConsole( 0xFFFFFFFF );
    }   
 
    ...
    [DllImport( "kernel32", SetLastError = true )]
    private static extern bool AttachConsole( uint dwProcessId );

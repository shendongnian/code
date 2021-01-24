    private static string ReadALineOfConsoleOutput(IntPtr stdout)
    {
        if (stdout.ToInt32() == INVALID_HANDLE_VALUE)
            throw new Win32Exception();
        // this assumes the console screen buffer is 80 columns wide. 
        // You can call GetConsoleScreenBufferInfo() to get its actual dimensions.
        uint nLength = 80;
        StringBuilder lpCharacter = new StringBuilder((int)nLength);
        // read from the first character of the first line (0, 0).
        COORD dwReadCoord;
        dwReadCoord.X = 0;
        dwReadCoord.Y = 0;
        uint lpNumberOfCharsRead = 0;
        if (!ReadConsoleOutputCharacter(stdout, lpCharacter, nLength, dwReadCoord, out lpNumberOfCharsRead))
            throw new Win32Exception();
        return lpCharacter.ToString();
    }
    public static async Task Main()
    {
        var processId = 8560;
        if (!FreeConsole()) return ;
        if (!AttachConsole(processId)) return;
        IntPtr stdout = GetStdHandle(STD_OUTPUT_HANDLE);
        var r1 = ReadALineOfConsoleOutput(stdout);
        
        //write to file or somewhere
    }

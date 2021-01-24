    private static string ReadALineOfConsoleOutput(IntPtr stdout, ref short currentPosition)
    {
        if (stdout.ToInt32() == INVALID_HANDLE_VALUE)
            throw new Win32Exception();
        //Get Console Info
        if (!GetConsoleScreenBufferInfo(stdout, out CONSOLE_SCREEN_BUFFER_INFO outInfo))
            throw new Win32Exception();
        //Gets Console Output Line Size
        short lineSize = outInfo.dwSize.X;
        //Calculates Number of Lines to be read
        uint numberofLinesToRead = (uint)(outInfo.dwCursorPosition.Y - currentPosition);
        if (numberofLinesToRead < 1) return null;
        // read from the first character of the first line (0, 0).
        COORD dwReadCoord;
        dwReadCoord.X = 0;
        dwReadCoord.Y = currentPosition;
        //total characters to be read
        uint nLength = (uint)lineSize * numberofLinesToRead + 2*numberofLinesToRead;
        StringBuilder result = new StringBuilder((int)nLength);
        StringBuilder lpCharacter = new StringBuilder(lineSize);
        for (int i = 0; i < numberofLinesToRead; i++)
        {
            if (!ReadConsoleOutputCharacter(stdout, lpCharacter, (uint) lineSize, dwReadCoord, out uint lpNumberOfCharsRead))
                throw new Win32Exception();
            result.AppendLine(lpCharacter.ToString(0, (int)lpNumberOfCharsRead-1));
            dwReadCoord.Y++;
        }
        currentPosition = outInfo.dwCursorPosition.Y;
        return result.ToString();
    }
    public static async Task Main()
    {
        var processId = 8560;
        if (!FreeConsole()) return ;
        if (!AttachConsole(processId)) return;
        IntPtr stdout = GetStdHandle(STD_OUTPUT_HANDLE);
        short currentPosition = 0;
        while (true)
        {
            var r1 = ReadALineOfConsoleOutput(stdout, ref currentPosition);
            if (r1 != null)
                //write to file or somewhere => //Debug.WriteLine(r1);
        }
    }

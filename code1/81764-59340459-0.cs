c#
using System;
using System.Windows.Forms;
public static void Main(string[] args)
{
    if (args.Length > 0)
    {
        using (new ConsoleScope())
        {
            Console.WriteLine("I now own the console");
            Console.WriteLine("MUA HA HA HA HA HA!!!");
        }
    }
    else
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
... and now for the code. It's more than I'd like, but this is as succinct as I could make it for a post. May this help others attempting the same thing. Enjoy!
c#
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
public sealed class ConsoleScope : IDisposable
{
	const int ATTACH_PARENT_PROCESS = -1;
	const int STD_OUTPUT_HANDLE = -11;
	readonly bool createdNewConsole;
	readonly string prompt;
	bool disposed;
	public ConsoleScope()
	{
        if (AttachParentConsole())
        {
            prompt = CaptureParentConsoleCurrentPrompt();
        }
        else
        {
            AllocConsole();
            createdNewConsole = true;
        }
    }
    ~ConsoleScope() => CleanUp();
    public void Dispose()
    {
        CleanUp();
        GC.SuppressFinalize(this);
    }
    static string CaptureParentConsoleCurrentPrompt()
    {
        var line = (short)Console.CursorTop;
        var length = (short)Console.CursorLeft;
        var noPrompt = line == 0 && length == 0;
        if (noPrompt)
        {
            return default;
        }
        return ReadCurrentLineFromParentConsoleBuffer(line, length);
    }
    static string ReadCurrentLineFromParentConsoleBuffer(short line, short length)
    {
        var itemSize = Marshal.SizeOf(typeof(CHAR_INFO));
        var buffer = Marshal.AllocHGlobal(length * itemSize);
        var encoding = Console.OutputEncoding;
        var text = new StringBuilder(capacity: length + 1);
        var coordinates = default(COORD);
        var textRegion = new SMALL_RECT
        {
            Left = 0,
            Top = line,
            Right = (short)(length - 1),
            Bottom = line,
        };
        var bufferSize = new COORD
        {
            X = length,
            Y = 1,
        };
        try
        {
            if (!ReadConsoleOutput(GetStdOutputHandle(), buffer, bufferSize, coordinates, ref textRegion))
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            var array = buffer;
            for (var i = 0; i < length; i++)
            {
                var info = Marshal.PtrToStructure<CHAR_INFO>(array);
                var chars = encoding.GetChars(info.CharData);
                text.Append(chars[0]);
                array += itemSize;
            }
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
        // now that we've captured the current prompt, overwrite it with spaces
        // so that things start where the parent left off at
        Console.SetCursorPosition(0, line);
        Console.Write(new string(' ', length));
        Console.SetCursorPosition(0, line - 1);
        return text.ToString();
    }
    void CleanUp()
    {
        if (disposed)
        {
            return;
        }
        disposed = true;
        RestoreParentConsolePrompt();
        if (createdNewConsole)
        {
            FreeConsole();
        }
    }
    void RestoreParentConsolePrompt()
    {
        var text = prompt;
        if (!string.IsNullOrEmpty(text))
        {
            // this assumes the last output from your application used
            // Console.WriteLine or otherwise output a CRLF. if it didn't,
            // you may need to add an extra line here
            Console.Write(text);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    struct CHAR_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] CharData;
        public short Attributes;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct COORD
    {
        public short X;
        public short Y;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct SMALL_RECT
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;
    }
    // REF: https://docs.microsoft.com/en-us/windows/console/allocconsole
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AllocConsole();
    // REF: https://docs.microsoft.com/en-us/windows/console/attachconsole
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(int dwProcessId);
    // REF: https://docs.microsoft.com/en-us/windows/console/freeconsole
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool FreeConsole();
    static bool AttachParentConsole() => AttachConsole(ATTACH_PARENT_PROCESS);
    // REF: https://docs.microsoft.com/en-us/windows/console/readconsoleoutput
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool ReadConsoleOutput(IntPtr hConsoleOutput, IntPtr lpBuffer, COORD dwBufferSize, COORD dwBufferCoord, ref SMALL_RECT lpReadRegion);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);
    static IntPtr GetStdOutputHandle() => GetStdHandle(STD_OUTPUT_HANDLE);
}

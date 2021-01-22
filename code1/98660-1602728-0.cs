//UNCOMMENT THIS LINE TO BREAK IT:
//#define BROKEN
using System;
using System.Runtime.InteropServices;
class ConIOBroken
{
    static void Main()
    {
        int nRead = 0;
        IntPtr handle = GetStdHandle(-10 /*STD_INPUT_HANDLE*/);
        Console.Write("Press the letter: 'a': ");
        INPUT_RECORD record = new INPUT_RECORD();
        do
        {
            ReadConsoleInputW(handle, ref record, 1, ref nRead);
        } while (record.EventType != 0x0001/*KEY_EVENT*/);
        Assert.AreEqual((short)0x0001, record.EventType);
        Assert.AreEqual(1u, record.KeyEvent.bKeyDown);
        Assert.AreEqual(0x00000000, record.KeyEvent.dwControlKeyState & ~0x00000020);//strip num-lock and test
        Assert.AreEqual('a', record.KeyEvent.UnicodeChar);
        Assert.AreEqual((short)0x0001, record.KeyEvent.wRepeatCount);
        Assert.AreEqual((short)0x0041, record.KeyEvent.wVirtualKeyCode);
        Assert.AreEqual((short)0x001e, record.KeyEvent.wVirtualScanCode);
        return;
    }
    static class Assert { public static void AreEqual(object x, object y) { if (!x.Equals(y)) throw new ApplicationException(); } }
    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr GetStdHandle(int nStdHandle);
    [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool ReadConsoleInputW(IntPtr hConsoleInput, ref INPUT_RECORD lpBuffer, int nLength, ref int lpNumberOfEventsRead);
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_RECORD
    {
        [FieldOffset(0)]
        public short EventType;
        //union {
        [FieldOffset(4)]
        public KEY_EVENT_RECORD KeyEvent;
        [FieldOffset(4)]
        public MOUSE_EVENT_RECORD MouseEvent;
        [FieldOffset(4)]
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
        [FieldOffset(4)]
        public MENU_EVENT_RECORD MenuEvent;
        [FieldOffset(4)]
        public FOCUS_EVENT_RECORD FocusEvent;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_EVENT_RECORD
    {
        public uint bKeyDown;
        public short wRepeatCount;
        public short wVirtualKeyCode;
        public short wVirtualScanCode;
        public char UnicodeChar;
        public int dwControlKeyState;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSE_EVENT_RECORD
    {
        public COORD dwMousePosition;
        public int dwButtonState;
        public int dwControlKeyState;
        public int dwEventFlags;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOW_BUFFER_SIZE_RECORD
    {
        public COORD dwSize;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MENU_EVENT_RECORD
    {
        public int dwCommandId;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct FOCUS_EVENT_RECORD
    {
        public uint bSetFocus;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        public short X;
        public short Y;
    }
}
</pre>

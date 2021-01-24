csharp
public class Program
{
    [DllImport("user32.dll", SetLastError = true)]
    static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    public const int KEYEVENTF_EXTENDEDKEY = 0x0001; // key down flag
    public const int KEYEVENTF_KEYUP = 0x0002; // key up flag
    public const int F12 = 123; // F12 key code
    public static void Main()
    {
        TimeSpan remainingTime; // Calculate the remaining time (possibly using DateTime.Now)
        // Wait until "certain time"
        Thread.Sleep((int)remainingTime.TotalMilliseconds);
        keybd_event(F12, 0, KEYEVENTF_EXTENDEDKEY, 0); // press F12 down
        keybd_event(F12, 0, KEYEVENTF_KEYUP, 0); // release F12
    }
}
It would be better to use a [Timer](https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer?view=netframework-4.7.2) instead, but it is not as easy to set up.

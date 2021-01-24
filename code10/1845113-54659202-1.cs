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
        const int hour = 4;
        const int min = 15;
        // Get DateTime at which the key is supposed to be pressed
        DateTime nextCertainTime = DateTime.Now.Date.AddHours(hour).AddMinutes(min);
        // If it is already too late for today, add 1 day (set to tomorrow)
        if (nextCertainTime < DateTime.Now)
        {
            nextCertainTime = nextCertainTime.AddDays(1);
        }
        // Calculate the remaining time
        TimeSpan remainingTime = nextCertainTime - DateTime.Now;
        // Wait until "certain time"
        Thread.Sleep((int)remainingTime.TotalMilliseconds);
        keybd_event(F12, 0, KEYEVENTF_EXTENDEDKEY, 0); // press F12 down
        keybd_event(F12, 0, KEYEVENTF_KEYUP, 0); // release F12
    }
}
If you want to do this repeatedly, just put it into a `while (true)` loop and add 1 day to `nextCertainTime` with each iteration.
It would be better to use a [Timer](https://docs.microsoft.com/en-us/dotnet/api/system.threading.timer?view=netframework-4.7.2) instead, but it is not as easy to set up.

    using System.Runtime.InteropServices;
    using UnityEngine;
    public class SimulateMouseClick
    {
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    //Mouse actions
    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;
    public static void Click()
    {
        //Call the imported function with the cursor's current position
        uint X = (uint)0;
        uint Y = (uint)0;
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        Debug.LogError("SIMULATED A MOUSE CLICK JUST NOW...");
    }
    //...other code needed for the application
    }

    using System;
    using System.Runtime.InteropServices;
    public class SimulatePCControl
    {
	[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);
    
    private const int VK_LEFT = 0x25;
	public static void LeftArrow()
    {
        keybd_event(VK_LEFT, 0, 0, 0);
    }
    }

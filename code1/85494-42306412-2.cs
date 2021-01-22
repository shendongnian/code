    using System;
    using System.Runtime.InteropServices; // For the P/Invoke signatures.
    public static class PositionWindowDemo
    {
    
        // P/Invoke declarations.
    	[DllImport("user32.dll", SetLastError = true)]
    	static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    	[DllImport("user32.dll", SetLastError = true)]
    	static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    
    	const uint SWP_NOSIZE = 0x0001;
    	const uint SWP_NOZORDER = 0x0004;
    
    	public static void Main()
    	{
            // Find (the first-in-Z-order) Notepad window.
    		IntPtr hWnd = FindWindow("Notepad", null);
            // If found, position it.
    		if (hWnd != IntPtr.Zero)
    		{
    			// Move the window to (0,0) without changing its size or position
    			// in the Z order.
    			SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
    		}
    	}
    
    }

    /// <summary>A variety of checks to see whether Excel is busy. This is required because
    /// in recent versions of Excel, invoking Recalculate can interrupt user activity.</summary>
    private static bool IsExcelBusy(Application xlApp)
    {
        try
        {
            // Check whether the main Excel application window is currently in the foreground
            // We do this by getting Excel's native window handle, and that of the foreground window
            IntPtr xlHwnd = (IntPtr)xlApp.Hwnd;
            IntPtr foreground = NativeMethods.GetForegroundWindow();
            if (xlHwnd != foreground)
            {
                // If the main Excel window is not in the foreground, see who owns the
                // foreground window by getting the id of each window's owning process.
                NativeMethods.GetWindowThreadProcessId(xlHwnd, out uint xlProc);
                NativeMethods.GetWindowThreadProcessId(foreground, out uint foregroundProc);
                // If the foreground window is owned by the Excel application, return busy
                // If the foreground window is some other process, Excel itself is not busy.
                return xlProc == foregroundProc;
            }
            // If the main excel window is active, ensure the user isn't doing anything.
    
            // Check if the user currently has a downed mouse button (to avoid interrupting
            // drag operations within the Excel application)
            if (Control.MouseButtons != MouseButtons.None)
                return true;
    
            // TODO: Check whether the user's cursor in some other Excel control (like
            //       renaming a sheet, typing in the Named Range box, typing in the Font box, etc.
    
            // The user is editing a formula if Interactive is true and cannot be set to false.
            // https://www.add-in-express.com/creating-addins-blog/2011/03/23/excel-check-user-edit-cell/
            // NOTE: Even setting App.Interactive can interrupt user activity, so do this test last.
            if (xlApp.Interactive)
            {
                xlApp.Interactive = false;
                xlApp.Interactive = true;
            }
    
            // Otherwise, assume Excel is not busy.
            return false;
        }
        catch (AccessViolationException)
        {
            return true;
        }
        catch (COMException)
        {
            return true;
        }
    }

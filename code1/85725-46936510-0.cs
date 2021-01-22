    static IEnumerable<Form> EnumOpenForms()
    {
        foreach (System.Diagnostics.ProcessThread thread in System.Diagnostics.Process.GetCurrentProcess().Threads)
        {
            List<IntPtr> hWnds = new List<IntPtr>();
            EnumThreadWindows(thread.Id, (hWnd, param) => { hWnds.Add(hWnd); }, IntPtr.Zero);
            foreach(IntPtr hWnd in hWnds)
            {
                Form form = Control.FromHandle(hWnd) as Form;
                if (form != null)
                {
                    yield return form;
                }
            }
        }
    }
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern bool EnumThreadWindows(int dwThreadId, EnumWindowProc lpEnumFunc, IntPtr lParam);
    delegate void EnumWindowProc(IntPtr hWnd, IntPtr parameter);

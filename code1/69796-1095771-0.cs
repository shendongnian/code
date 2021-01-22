    [System.Runtime.InteropServices.DllImport("user32.dll")]
    
    private static extern int SetWindowLong(System.Runtime.InteropServices.HandleRef hWnd, int nIndex, int dwNewLong);
    
    /// <summary>
    /// sets the owner of a System.Windows.Forms.Form to a System.Windows.Window
    /// </summary>
    /// <param name="form"></param>
    /// <param name="owner"></param>
    public static void SetOwner(System.Windows.Forms.Form form, System.Windows.Window owner)
    {
    	System.Windows.Interop.WindowInteropHelper helper = new System.Windows.Interop.WindowInteropHelper(owner);
    	SetWindowLong(new System.Runtime.InteropServices.HandleRef(form, form.Handle), -8, helper.Handle.ToInt32());
    }

    [DllImport("user32.dll")]
    
    private static extern int SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);
    
    /// <summary>
    /// sets the owner of a System.Windows.Forms.Form to a System.Windows.Window
    /// </summary>
    /// <param name="form"></param>
    /// <param name="owner"></param>
    public static void SetOwner(System.Windows.Forms.Form form, System.Windows.Window owner)
    {
    	WindowInteropHelper helper = new WindowInteropHelper(owner);
    	SetWindowLong(new HandleRef(form, form.Handle), -8, helper.Handle.ToInt32());
    }

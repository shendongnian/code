    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
    
    public static void SetOwner(IWin32Window child, IWin32Window owner)
    {
        NativeMethods.SetWindowLong(
            new HandleRef(child, child.Handle), 
            -8, // GWL_HWNDPARENT
            new HandleRef(owner, owner.Handle));
    }

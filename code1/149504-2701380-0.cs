    public static System.Drawing.Icon GetFileIcon(string name, IconSize size, 
                                                  bool linkOverlay)
    {
        Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
        uint flags = Shell32.SHGFI_ICON | Shell32.SHGFI_USEFILEATTRIBUTES;
        
        if (true == linkOverlay) flags += Shell32.SHGFI_LINKOVERLAY;
    
    
        /* Check the size specified for return. */
        if (IconSize.Small == size)
        {
            flags += Shell32.SHGFI_SMALLICON ; // include the small icon flag
        } 
        else 
        {
            flags += Shell32.SHGFI_LARGEICON ;  // include the large icon flag
        }
        
        Shell32.SHGetFileInfo( name, 
            Shell32.FILE_ATTRIBUTE_NORMAL, 
            ref shfi, 
            (uint) System.Runtime.InteropServices.Marshal.SizeOf(shfi), 
            flags );
    
    
        // Copy (clone) the returned icon to a new object, thus allowing us 
        // to call DestroyIcon immediately
        System.Drawing.Icon icon = (System.Drawing.Icon)
                             System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
        User32.DestroyIcon( shfi.hIcon ); // Cleanup
        return icon;
    }

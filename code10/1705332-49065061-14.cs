    private IntPtr hSysMenu;
    hSysMenu = GetSystemMenu(someform.Handle, false);
    private void InsertMenu(uint id, uint icIndex, string icText, IntPtr hBitmap)
    {
        MenuItemInfo mInfo = new MenuItemInfo()
        {
            cbSize = (uint)Marshal.SizeOf(typeof(MenuItemInfo)),
            fMask = InsMenuFlags,
            fType = MenuItemInfo_fType.MFT_STRING,
            fState = MenuItemInfo_fState.MFS_ENABLED,
            wID = id,
            hbmpItem = hBitmap,
            hbmpChecked = hBitmap,
            hbmpUnchecked = hBitmap,
            dwTypeData = Marshal.StringToHGlobalAuto(icText),
            dwItemData = IntPtr.Zero,
            hSubMenu = IntPtr.Zero,
            cch = (uint)icText.Length,
        };
    
        InsertMenuItem(hSysMenu, icIndex, true, ref mInfo);
    }

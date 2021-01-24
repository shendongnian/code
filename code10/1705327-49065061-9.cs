    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
    internal static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition, ref MenuItemInfo lpmii);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    public enum MenuItemInfo_fMask : uint
    {
        MIIM_BITMAP = 0x00000080,           //Retrieves or sets the hbmpItem member.
        MIIM_CHECKMARKS = 0x00000008,       //Retrieves or sets the hbmpChecked and hbmpUnchecked members.
        MIIM_DATA = 0x00000020,             //Retrieves or sets the dwItemData member.
        MIIM_FTYPE = 0x00000100,            //Retrieves or sets the fType member.
        MIIM_ID = 0x00000002,               //Retrieves or sets the wID member.
        MIIM_STATE = 0x00000001,            //Retrieves or sets the fState member.
        MIIM_STRING = 0x00000040,           //Retrieves or sets the dwTypeData member.
        MIIM_SUBMENU = 0x00000004,          //Retrieves or sets the hSubMenu member.
        MIIM_TYPE = 0x00000010,             //Retrieves or sets the fType and dwTypeData members.
                                            //MIIM_TYPE is replaced by MIIM_BITMAP, MIIM_FTYPE, and MIIM_STRING.
    }
    public enum MenuItemInfo_fType : uint
    {
        MFT_BITMAP = 0x00000004,            //Displays the menu item using a bitmap. The low-order word of the dwTypeData member is the bitmap handle, and the cch member is ignored.
                                            //MFT_BITMAP is replaced by MIIM_BITMAP and hbmpItem.
        MFT_MENUBARBREAK = 0x00000020,      //Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.
        MFT_MENUBREAK = 0x00000040,         //Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
        MFT_OWNERDRAW = 0x00000100,         //Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a WM_MEASUREITEM message before the menu is displayed for the first time, and a WM_DRAWITEM message whenever the appearance of the menu item must be updated. If this value is specified, the dwTypeData member contains an application-defined value.
        MFT_RADIOCHECK = 0x00000200,        //Displays selected menu items using a radio-button mark instead of a check mark if the hbmpChecked member is NULL.
        MFT_RIGHTJUSTIFY = 0x00004000,      //Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.
        MFT_RIGHTORDER = 0x00002000,        //Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support right-to-left languages, such as Arabic and Hebrew.
        MFT_SEPARATOR = 0x00000800,         //Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line. The dwTypeData and cch members are ignored. This value is valid only in a drop-down menu, submenu, or shortcut menu.
        MFT_STRING = 0x00000000             //Displays the menu item using a text string. The dwTypeData member is the pointer to a null-terminated string, and the cch member is the length of the string.
                                            //MFT_STRING is replaced by MIIM_STRING.
    }
    //The menu item state. This member can be one or more of these values. Set fMask to MIIM_STATE to use fState. 
    public enum MenuItemInfo_fState : uint
    {
        MFS_CHECKED = 0x00000008,           //Checks the menu item. For more information about selected menu items, see the hbmpChecked member.
        MFS_DEFAULT = 0x00001000,           //Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed in bold.
        MFS_DISABLED = 0x00000003,          //Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_GRAYED.
        MFS_ENABLED = 0x00000000,           //Enables the menu item so that it can be selected. This is the default state.
        MFS_GRAYED = 0x00000003,            //Disables the menu item and grays it so that it cannot be selected. This is equivalent to MFS_DISABLED.
        MFS_HILITE = 0x00000080,            //Highlights the menu item.
        MFS_UNCHECKED = 0x00000000,         //Unchecks the menu item. For more information about clear menu items, see the hbmpChecked member.
        MFS_UNHILITE = 0x00000000,          //Removes the highlight from the menu item. This is the default state.
    }
    //A handle to the bitmap to be displayed, or it can be one of the values in the following Enum. 
    //It is used when the MIIM_BITMAP flag is set in the fMask member. (ex. (hBitmap)HBMMENU_SYSTEM)
    public enum MenuItemInfo_hItem
    {
        HBMMENU_CALLBACK = -1,              //A bitmap that is drawn by the window that owns the menu. The application must process the WM_MEASUREITEM and WM_DRAWITEM messages.
        HBMMENU_MBAR_CLOSE = 5,             //Close button for the menu bar.
        HBMMENU_MBAR_CLOSE_D = 6,           //Disabled close button for the menu bar.
        HBMMENU_MBAR_MINIMIZE = 3,          //Minimize button for the menu bar.
        HBMMENU_MBAR_MINIMIZE_D = 7,        //Disabled minimize button for the menu bar.
        HBMMENU_MBAR_RESTORE = 2,           //Restore button for the menu bar.
        HBMMENU_POPUP_CLOSE = 8,            //Close button for the submenu.
        HBMMENU_POPUP_MAXIMIZE = 10,        //Maximize button for the submenu.
        HBMMENU_POPUP_MINIMIZE = 11,        //Minimize button for the submenu.
        HBMMENU_POPUP_RESTORE = 9,          //Restore button for the submenu.
        HBMMENU_SYSTEM = 1,                 //Windows icon or the icon of the window specified in dwItemData.
    }
    public struct MenuItemInfo
    {
        public uint cbSize;                 //The size of the structure, in bytes. The caller must set this member to sizeof(MENUITEMINFO). 
        public MenuItemInfo_fMask fMask;    //See MenuItemInfo_fMask
        public MenuItemInfo_fType fType;    //See MenuItemInfo_fType
        public MenuItemInfo_fState fState;  //See MenuItemInfo_fState
        public uint wID;                    //An application-defined value that identifies the menu item. Set fMask to MIIM_ID to use wID.
        public IntPtr hSubMenu;             //A handle to the drop-down menu or submenu associated with the menu item. If the menu item is not an item that opens a drop-down menu or submenu, this member is NULL. Set fMask to MIIM_SUBMENU to use hSubMenu.
        public IntPtr hbmpChecked;          //A handle to the bitmap to display next to the item if it is selected. If this member is NULL, a default bitmap is used. If the MFT_RADIOCHECK type value is specified, the default bitmap is a bullet. Otherwise, it is a check mark. Set fMask to MIIM_CHECKMARKS to use hbmpChecked.
        public IntPtr hbmpUnchecked;        //A handle to the bitmap to display next to the item if it is not selected. If this member is NULL, no bitmap is used. Set fMask to MIIM_CHECKMARKS to use hbmpUnchecked. 
        public IntPtr dwItemData;           //An application-defined value associated with the menu item. Set fMask to MIIM_DATA to use dwItemData.
        public IntPtr dwTypeData;           //The contents of the menu item. The meaning of this member depends on the value of fType and is used only if the MIIM_TYPE flag is set in the fMask member.
                                            //To retrieve a menu item of type MFT_STRING, first find the size of the string by setting the dwTypeData member of MENUITEMINFO to NULL and then calling GetMenuItemInfo. The value of cch+1 is the size needed. Then allocate a buffer of this size, place the pointer to the buffer in dwTypeData, increment cch, and call GetMenuItemInfo once again to fill the buffer with the string. If the retrieved menu item is of some other type, then GetMenuItemInfo sets the dwTypeData member to a value whose type is specified by the fType member.
                                            //When using with the SetMenuItemInfo function, this member should contain a value whose type is specified by the fType member.
                                            //dwTypeData is used only if the MIIM_STRING flag is set in the fMask member 
        public uint cch;                    //The length of the menu item text, in characters, when information is received about a menu item of the MFT_STRING type. However, cch is used only if the MIIM_TYPE flag is set in the fMask member and is zero otherwise. Also, cch is ignored when the content of a menu item is set by calling SetMenuItemInfo.
                                            //Note that, before calling GetMenuItemInfo, the application must set cch to the length of the buffer pointed to by the dwTypeData member. If the retrieved menu item is of type MFT_STRING (as indicated by the fType member), then GetMenuItemInfo changes cch to the length of the menu item text. If the retrieved menu item is of some other type, GetMenuItemInfo sets the cch field to zero.
                                            //The cch member is used when the MIIM_STRING flag is set in the fMask member.
        public IntPtr hbmpItem;             //A handle to the bitmap to be displayed, or it can be one of the values MenuItemInfo_hItem Enum. It is used when the MIIM_BITMAP flag is set in the fMask member. 
    };

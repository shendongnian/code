            [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);
        public static void EnableCloseButton(Form frm, bool enabled) {
            IntPtr hMenu;
            int n;
            hMenu = GetSystemMenu(frm.Handle, false);
            if (hMenu != IntPtr.Zero) {
                n = GetMenuItemCount(hMenu);
                if (n > 0) {
                    if (enabled) {
                        EnableClose(frm);
                    }
                    else {
                        DisableClose(frm);
                    }
                    SendMessage(frm.Handle, WM_NCACTIVATE, (IntPtr)1, (IntPtr)0);
                    DrawMenuBar(frm.Handle);
                    Application.DoEvents();
                }
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MENUITEMINFO {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public int wID;
            public int hSubMenu;
            public int hbmpChecked;
            public int hbmpUnchecked;
            public int dwItemData;
            public string dwTypeData;
            public uint cch;
            //    public int hbmpItem;
        }
        internal const UInt32 SC_CLOSE = 0xF060;
        //SetMenuItemInfo fMask constants.
        const UInt32 MIIM_STATE = 0x1;
        const UInt32 MIIM_ID = 0x2;
        //'SetMenuItemInfo fState constants.
        const UInt32 MFS_ENABLED = 0x0;
        const UInt32 MFS_GRAYED = 0x3;
        const UInt32 MFS_CHECKED = 0x8;
        internal const int MFS_DEFAULT = 0x1000;
        [DllImport("user32.dll")]
        static extern bool SetMenuItemInfo(IntPtr hMenu, int uItem, bool fByPosition, [In] ref MENUITEMINFO lpmii);
        [DllImport("user32.dll")]
        static extern bool GetMenuItemInfo(IntPtr hMenu, int uItem, bool fByPosition, ref MENUITEMINFO lpmii);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        private const UInt32 WM_NCACTIVATE = 0x0086;
        private static void DisableClose(Form frm) {
            IntPtr hMenu;
            int n;
            hMenu = GetSystemMenu(frm.Handle, false);
            if (hMenu != IntPtr.Zero) {
                MENUITEMINFO mif = new MENUITEMINFO();
                mif.cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO));
                mif.fMask = MIIM_ID | MIIM_STATE;
                mif.fType = 0;
                mif.dwTypeData = null;
                bool a = GetMenuItemInfo(hMenu, (int)SC_CLOSE, false, ref mif);
                mif.fState = MFS_GRAYED;
                SetMenuItemInfo(hMenu, (int)SC_CLOSE, false, ref mif);
                SendMessage(frm.Handle, WM_NCACTIVATE, (IntPtr)1, (IntPtr)0);
                mif.wID = -10;
                mif.fState = MFS_GRAYED;
                SetMenuItemInfo(hMenu, (int)SC_CLOSE, false, ref mif);
            }
        }
        private static void EnableClose(Form frm) {
            IntPtr hMenu;
            int n;
            hMenu = GetSystemMenu(frm.Handle, false);
            if (hMenu != IntPtr.Zero) {
                MENUITEMINFO mif = new MENUITEMINFO();
                mif.cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO));
                mif.fMask = MIIM_ID | MIIM_STATE;
                mif.fType = 0;
                mif.dwTypeData = null;
                bool a = GetMenuItemInfo(hMenu, -10, false, ref mif);
                mif.wID = (int)SC_CLOSE;
                SetMenuItemInfo(hMenu, -10, false, ref mif);
                SendMessage(frm.Handle, WM_NCACTIVATE, (IntPtr)1, (IntPtr)0);
                mif.fState = MFS_ENABLED;
                SetMenuItemInfo(hMenu, (int)SC_CLOSE, false, ref mif);
                SendMessage(frm.Handle, WM_NCACTIVATE, (IntPtr)1, (IntPtr)0);
            }
        }

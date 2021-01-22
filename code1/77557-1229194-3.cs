      [StructLayout(LayoutKind.Sequential)]
        public struct DRAWITEMSTRUCT
        {
            public int CtlType;
            public int CtlID;
            public int itemID;
            public int itemAction;
            public int itemState;
            public IntPtr hwndItem;
            public IntPtr hDC;
            public RECT rcItem;
            public IntPtr itemData;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public int Width
            {
                get { return right - left; }
            }
            public int Height
            {
                get { return bottom - top; }
            }
        }
    
        public enum ListViewDefaults
        {
            LVS_OWNERDRAWFIXED = 0x0400
        }
        
        public enum WMDefaults
        {
            WM_DRAWITEM = 0x002B,
            WM_REFLECT = 0x2000
        }

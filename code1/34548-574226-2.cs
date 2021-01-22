    class ExplorerListView : NativeWindow
    {
        public event EventHandler<ExecuteEventArgs> ItemExecuted;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int LVM_GETNEXTITEM = 0x100C;
        private const int LVM_GETITEMTEXT = 0x1073;
        private const int LVNI_SELECTED = 0x0002;
        private const string EXPLORER_LISTVIEW_CLASS = "SysListView32";
        public ExplorerListView(IntPtr shellViewHandle)
        {
            base.AssignHandle(FindWindowEx(shellViewHandle, IntPtr.Zero, 
                EXPLORER_LISTVIEW_CLASS, null));
            if (base.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("Window supplied does not encapsulate an explorer window.");
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDBLCLK:
                    if (OnItemExecution() != 0) return;
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        private int OnItemExecution()
        {
            int cancel = 0;
            ExecuteEventArgs args = new ExecuteEventArgs(GetSelectedItem());
            EventHandler<ExecuteEventArgs> temp = ItemExecuted;
            if (temp != null)
            {
                temp(this, args);
                if (args.Cancel) cancel = 1;
            }
            return cancel;
        }
        private string GetSelectedItem()
        {
            string item = null;
            IntPtr pStringBuffer = Marshal.AllocHGlobal(2048);
            IntPtr pItemBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(LVITEM)));
            int selectedItemIndex = SendMessage(base.Handle, LVM_GETNEXTITEM, (IntPtr)(-1), (IntPtr)LVNI_SELECTED).ToInt32();
            if (selectedItemIndex > -1)
            {
                LVITEM lvi = new LVITEM();
                lvi.cchTextMax = 1024;
                lvi.pszText = pStringBuffer;
                Marshal.StructureToPtr(lvi, pItemBuffer, false);
                int numChars = SendMessage(base.Handle, LVM_GETITEMTEXT, (IntPtr)selectedItemIndex, pItemBuffer).ToInt32();
                if (numChars > 0)
                {
                    item = Marshal.PtrToStringUni(lvi.pszText, numChars);
                }
            }
            Marshal.FreeHGlobal(pStringBuffer);
            Marshal.FreeHGlobal(pItemBuffer);
            return item;
        }
        struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            int cColumns; // tile view columns
            public IntPtr puColumns;
            public IntPtr piColFmt;
            public int iGroup;
        }
    }
    public class ExecuteEventArgs : EventArgs
    {
        public string SelectedItem { get; private set; }
        public bool Cancel { get; set; }
        internal ExecuteEventArgs(string selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }

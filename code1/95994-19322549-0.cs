    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
                public Form1()
        {
            InitializeComponent();
            IntPtr hMenu = GetSystemMenu(Handle, false);
            if (hMenu != IntPtr.Zero)
            {
                var menuInfo = new MENUITEMINFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(MENUITEMINFO)),
                    cch = 255,
                    dwTypeData = "Test Item",
                    fMask = 0x1 | 0x2 | 0x10,
                    fState = 0,
                    // Add an ID for your Menu Item
                    wID = 0x1,  
                    fType = 0x0
                };
                InsertMenuItem(hMenu, 0, true, ref menuInfo);
                DrawMenuBar(Handle);
            }
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool InsertMenuItem(IntPtr hMenu, uint uItem,
                          bool fByPosition, [In] ref MENUITEMINFO lpmii);
        [StructLayout(LayoutKind.Sequential)]
        public struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;
        }
        // Add ID for the Menu
        private const int WM_SYSCOMMAND = 0x112; 
        // Event method for the Menu
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
                                                //m.WParam = the wID you gave the Menu Item
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == 0x1))
            {
                MessageBox.Show("Test Item Dialog");
            }
        }
    }
}

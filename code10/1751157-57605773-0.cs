        [DllImport("user32.dll")]
        public static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevmode, int dwFlags, uint dwDesiredAccess, IntPtr lpsa);
        [DllImport("user32.dll")]
        private static extern bool SwitchDesktop(IntPtr hDesktop);
        [DllImport("user32.dll")]
        public static extern bool CloseDesktop(IntPtr handle);
        [DllImport("user32.dll")]
        public static extern bool SetThreadDesktop(IntPtr hDesktop);
        [DllImport("user32.dll")]
        public static extern IntPtr GetThreadDesktop(int dwThreadId);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        enum DesktopAccess : uint
        {
            DesktopReadobjects = 0x0001,
            DesktopCreatewindow = 0x0002,
            DesktopCreatemenu = 0x0004,
            DesktopHookcontrol = 0x0008,
            DesktopJournalrecord = 0x0010,
            DesktopJournalplayback = 0x0020,
            DesktopEnumerate = 0x0040,
            DesktopWriteobjects = 0x0080,
            DesktopSwitchdesktop = 0x0100,
            GenericAll = DesktopReadobjects | DesktopCreatewindow | DesktopCreatemenu |
                         DesktopHookcontrol | DesktopJournalrecord | DesktopJournalplayback |
                         DesktopEnumerate | DesktopWriteobjects | DesktopSwitchdesktop
        }
        public Form1()
        {
            InitializeComponent();
        }
        //You must press this button to start
        private void btnInit_Click(object sender, EventArgs e)
        {
            Init();
        }
        private static void Init()
        {
            // old desktop's handle, obtained by getting the current desktop assigned for this thread
            var hOldDesktop = GetThreadDesktop(GetCurrentThreadId());
            // new desktop's handle, assigned automatically by CreateDesktop
            var hNewDesktop = CreateDesktop(GetRandomName(), IntPtr.Zero, IntPtr.Zero, 0, (uint)DesktopAccess.GenericAll, IntPtr.Zero);
            // switching to the new desktop
            SwitchDesktop(hNewDesktop);
            // Random login form: used for testing / not required
            var passwd = "";
            // running on a different thread, this way SetThreadDesktop won't fail
            Task.Factory.StartNew(() =>
            {
                // assigning the new desktop to this thread - so the Form will be shown in the new desktop)
                SetThreadDesktop(hNewDesktop);
                var inbox = new CustomInbox();
                inbox.FormClosing += (sender, e) => { passwd = inbox.Value; };
                Application.Run(inbox);
            }).Wait();  // waits for the task to finish
            // end of login form
            // if got here, the form is closed => switch back to the old desktop
            SwitchDesktop(hOldDesktop);
            // disposing the secure desktop since it's no longer needed
            CloseDesktop(hNewDesktop);
            MessageBox.Show(@"Password, typed inside secure desktop: " + passwd, @"Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //This get a random name for the new desktop
        private static string GetRandomName()
        {
            var value = DateTime.Now.ToLongTimeString();
            value = value.GetHashCode().ToString().Replace("-", "").ToLowerInvariant();
            return value;
        }

     [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        private Process s;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.s = new Process();
            s.StartInfo.FileName = "notepad";
            s.Start();
            s.WaitForInputIdle();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //ShowWindow(s.MainWindowHandle, SW_RESTORE);
            SetForegroundWindow(s.MainWindowHandle);
            SendKeys.SendWait("Hello");
        }
    }

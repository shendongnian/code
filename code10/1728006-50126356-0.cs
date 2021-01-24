    public partial class Test : Form
    {
        private IntPtr testPic;
        private IntPtr hWinEventHook;
        private Process Target;
        private WinApi.RECT rect = new WinApi.RECT();
        protected Hook.WinEventDelegate WinEventDelegate;
        public Test(Form toCover, AxAXVLC.AxVLCPlugin2 ply)
        {
            InitializeComponent();
            WinEventDelegate = new Hook.WinEventDelegate(WinEventCallback);
            this.SetTopLevel(true);
            this.TopMost = true;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Show(toCover);
            toCover.Focus();
			
            try
            {
                Target = Process.GetProcessesByName("TestPlayer").FirstOrDefault(p => p != null);
                if (Target != null)
                {
                    testPic = Target.MainWindowHandle;
                    uint TargetThreadId = Hook.GetWindowThread(testPic);
                    if (testPic != IntPtr.Zero)
                    {
                        hWinEventHook = Hook.WinEventHookOne(Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE,
                                                             WinEventDelegate,
                                                             (uint)Target.Id,
                                                             TargetThreadId);
                        rect = Hook.GetWindowRect(testPic);
                    }
                    if (ply.video.fullscreen == true) 
                    {
                        Debug.WriteLine("yes is ");
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        protected void WinEventCallback(IntPtr hWinEventHook,
                                    Hook.SWEH_Events eventType,
                                    IntPtr hWnd,
                                    Hook.SWEH_ObjectId idObject,
                                    long idChild,
                                    uint dwEventThread,
                                    uint dwmsEventTime)
        {
            if (hWnd == testPic &&
                eventType == Hook.SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE &&
                idObject == (Hook.SWEH_ObjectId)Hook.SWEH_CHILDID_SELF)
            {
                WinApi.RECT rect = Hook.GetWindowRect(hWnd);
                //this.Location = new System.Drawing.Point(rect.Left, rect.Top);
            }
        }
        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hook.WinEventUnhook(hWinEventHook);
        }
        private void Overlay_FormShown(object sender, EventArgs e)
        {
            
            this.BeginInvoke(new Action(() => this.Owner.Activate()))
			this.Location = toCover.PointToScreen(System.Drawing.Point.Empty);
            if (Target == null)
            {
                this.Hide();
                MessageBox.Show("Player not found!", "Target Missing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
        }
        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
        private void Test_load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y); 
        }
        private void closeFullScreen_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
		
    }

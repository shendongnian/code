    using System.Management;
    using System.Runtime.InteropServices;
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        ManagementEventWatcher watcher;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            watcher = new ManagementEventWatcher(
                "Select * From Win32_ProcessStartTrace Where ProcessName = 'mspaint.exe'");
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Start();
        }
        void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var id = (UInt32)e.NewEvent["ProcessID"];
            var process = System.Diagnostics.Process.GetProcessById((int)id);
            this.Invoke(new MethodInvoker(() => {
                SetParent(process.MainWindowHandle, panel1.Handle);
            }));
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            watcher.Stop();
            watcher.Dispose();
            base.OnFormClosed(e);
        }
    }

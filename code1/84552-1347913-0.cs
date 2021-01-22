    public static class NativeMethods
    {
        public const byte VK_NUMLOCK = 0x90;
        public const uint KEYEVENTF_EXTENDEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0x2;
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        public static void SimulateKeyPress(byte keyCode)
        {
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
    public partial class Form1 : Form
    {
        private bool protectKeys; // To protect from inifite keypress chain reactions
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (protectKeys)
                return;
            if (e.KeyCode == Keys.NumLock && 
                !(new Microsoft.VisualBasic.Devices.Keyboard().NumLock))
            {
                protectKeys = true;
                NativeMethods.SimulateKeyPress(NativeMethods.VK_NUMLOCK);
                protectKeys = false;
            }
        }
    }

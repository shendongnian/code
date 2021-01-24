    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            var tb = new TextBox() { Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill, Text = string.Concat(Enumerable.Repeat("foo! ", 10000)) };
            Controls.Add(tb);
            DisableBouncing();
            FormClosed += (s, e) => RestoreBouncing();//for brevity just on Close
        }
        int? defaultSetting = null;
        private void DisableBouncing()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Wisp\Touch", true))
            {
                defaultSetting = key.GetValue(@"Bouncing", null) as int?;
                key.SetValue(@"Bouncing", 0x00000000, RegistryValueKind.DWord);
            }
        }
        private void RestoreBouncing()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Wisp\Touch", true))
            {
                key.SetValue(@"Bouncing", defaultSetting ?? 0, RegistryValueKind.DWord);
            }
        }
    }

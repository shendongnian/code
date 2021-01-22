    static class Program
    {
        [STAThread]
        static void Main()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = System.Drawing.SystemIcons.Application;
            icon.Click += delegate { MessageBox.Show("Bye!"); icon.Visible = false; Application.Exit(); };
            icon.Visible = true;
            Application.Run();
        }
    }

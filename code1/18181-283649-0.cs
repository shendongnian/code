    static class Program
    {
        [STAThread]
        static void Main()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = new System.Drawing.Icon(@"F:\Manager\Manager.ico");
            icon.Click += delegate { MessageBox.Show("Bye!"); icon.Visible = false; Application.Exit(); };
            icon.Visible = true;
            Application.Run();
        }
    }

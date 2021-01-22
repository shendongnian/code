    using System;
    using System.Drawing;
    using System.Windows.Forms;
    static class Program
    {
        static System.Threading.Timer test = 
            new System.Threading.Timer(Ticked, null, 5000, 0);
        [STAThread]
        static void Main(string[] args)
        {
            NotifyIcon ni = new NotifyIcon();
            ni.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ni.Visible = true;
            Application.Run();
            ni.Visible = false;
        }
        static void Ticked(object o) {
            Application.Exit();
        }
    }

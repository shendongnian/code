    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    namespace HiddenProgram
    {
    public class Program : ApplicationContext
    {
        [DllImport("user32")]
        static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        static extern int RegisterWindowMessage(string message);
        const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = Program.RegisterWindowMessage("com.holroyd.Gateway.Show");
        static Mutex mutex = new Mutex(true, "{9BFB3652-CCE9-42A2-8CDE-BBC40A0F5213}");
        MyForm form;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Show the single instance window
                PostMessage(
                    (IntPtr)HWND_BROADCAST,
                    WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
            else
            {
                // Create the hidden window
                Application.Run(new Program());
                mutex.ReleaseMutex();
            }
        }
        Program()
        {
            form = new MyForm();
            form.FormClosing += form_FormClosing;
        }
        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitThread();
        }
    }
    public class MyForm : Form
    {
        public MyForm()
        {
            CreateHandle();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Program.WM_SHOWME)
                Visible = !Visible;
            else
                base.WndProc(ref m);
        }
    }
    }

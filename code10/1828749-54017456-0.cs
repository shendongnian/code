    using Gma.System.MouseKeyHook;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class Form1 : System.Windows.Forms.Form
    {
        private Timer timer;
        private IKeyboardMouseEvents m_GlobalHook;
    
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            Subscribe();
    
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
    
            // Set up how the form should be displayed.
            ClientSize = new System.Drawing.Size(292, 266);
            Text = "Notify Icon Example";
    
            WindowState = FormWindowState.Minimized;
    
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width - 100,
                                      workingArea.Bottom - Size.Height - 100);
        }
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            TopMost = false;
        }
    
        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
    
            m_GlobalHook.MouseWheel += M_GlobalHook_MouseWheel;
        }
    
        private void M_GlobalHook_MouseWheel(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            TopMost = true;
            timer.Stop();
            timer.Start();
        }
    
        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= M_GlobalHook_MouseWheel;
    
            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }
    
    }
 

    using System;
    using System.Windows.Forms;
    class MyForm : Form
    {
        NotifyIcon sysTray;
    
        MyForm()
        {
            sysTray = new NotifyIcon();
            sysTray.Icon = System.Drawing.SystemIcons.Asterisk;
            sysTray.Visible = true;
            sysTray.Text = "Hi there";
            sysTray.MouseClick += delegate { MessageBox.Show("Boo!"); };
    
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Opacity = 0;
            WindowState = FormWindowState.Minimized;
        }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MyForm());
        }
    }

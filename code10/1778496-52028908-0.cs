    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Drawing;
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // do here whatever you want to do
            // just for testing...
            GetCursorPos(out Point lpPoint);
            this.Text = lpPoint.X + ", " + lpPoint.Y;
        }
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point p);
    }

    using System;
    using System.Windows.Forms;
    namespace SO_ToolTip
    {
        public partial class Form1 : Form
        {
            Random _Random = new Random();
            ToolTip _ToolTip = new ToolTip();
            public Form1()
            {
                InitializeComponent();
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                BringToFront();
                _ToolTip.Show("Blah blah... Blah blah... Blah blah...", this, _Random.Next(0, Width), _Random.Next(0, Height), 10000);
            }
        }
    }

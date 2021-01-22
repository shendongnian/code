    public partial class Form1 : Form
    {
        private ToolTip toolTip = new ToolTip();
        private Timer toolTipTimer = new Timer();
        private bool canShowToolTip = true;
    
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)0x00A0: // WM_NCMOUSEMOVE
                //case 0x2A0: // WM_NCMOUSEHOVER
                    if (m.WParam == new IntPtr(0x0002)) // HT_CAPTION
                    {
                        if (canShowToolTip)
                        {
                            canShowToolTip = false;
                            toolTip.Show(this.Text, this, this.PointToClient(Cursor.Position), toolTip.AutoPopDelay);
                            toolTipTimer.Start();
                        }
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    
        public Form1()
        {
            InitializeComponent();
            Form child = new Form();
            child.Text = "Program1 - Filename:[Really_long_filename_that_doesnt_fit.file] AAAAAAAAAAAAAAAAAAAA BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB";
            child.MdiParent = this;
            child.Show();
            toolTip.AutoPopDelay = 5000;
            toolTipTimer.Interval = toolTip.AutoPopDelay;
            toolTipTimer.Tick += delegate(object sender, EventArgs e)
            {
                canShowToolTip = true;
            };
        }
    }

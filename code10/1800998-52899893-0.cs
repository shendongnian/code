    public partial class Form1 : Form, IMessageFilter
    {
        private Panel pnl;
    
        public Form1()
        {
            InitializeComponent();
            pnl = new Panel { Size = new Size(200, 200), Location = new Point(20, 20), BackColor = Color.Aqua };
            Controls.Add(pnl);
            pnl.Click += panel_Click;
            pnl.MouseMove += panel_MouseMove;
            pnl.MouseHover += panel_MouseHover;
        }
     
        private void panel_MouseHover(sender As Object, e As EventArgs)
        {
            // this should not occur
            throw new NotImplementedException();
        }
   
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            // this should not occur
            throw new NotImplementedException();
        }
    
        private void panel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("panel clicked");
        }
    
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            // install message filter when form activates
            Application.AddMessageFilter(this);
        }
    
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            // remove message filter when form deactivates
            Application.RemoveMessageFilter(this);
        }
    
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            bool handled = false;
            if (m.HWnd == pnl.Handle && (WM) m.Msg == WM.MOUSEMOVE)
            {
                handled = true;
            }
            return handled;
        }
    
        public  enum WM : int
        {
            #region Mouse Messages
            MOUSEFIRST = 0x200,
            MOUSEMOVE = 0x200,
            LBUTTONDOWN = 0x201,
            LBUTTONUP = 0x202,
            LBUTTONDBLCLK = 0x203,
            RBUTTONDOWN = 0x204,
            RBUTTONUP = 0x205,
            RBUTTONDBLCLK = 0x206,
            MBUTTONDOWN = 0x207,
            MBUTTONUP = 0x208,
            MBUTTONDBLCLK = 0x209,
            MOUSELAST = 0x209
            #endregion
        }
    }

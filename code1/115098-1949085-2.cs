    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected void OnTitlebarClick(Point pos) {
            contextMenuStrip1.Show(pos);
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0xa4) {  // Trap WM_NCRBUTTONDOWN
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                OnTitlebarClick(pos);
                return;
            }
            base.WndProc(ref m);
        }
    }

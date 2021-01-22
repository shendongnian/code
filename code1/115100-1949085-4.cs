    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected void OnTitlebarClick(Point pos) {
            contextMenuStrip1.Show(pos);
        }
        protected override void WndProc(ref Message m) {
            const int WM_NCRBUTTONDOWN = 0xa4;
            if (m.Msg == WM_NCRBUTTONDOWN) { 
                var pos = new Point(m.LParam.ToInt32());
                OnTitlebarClick(pos);
                return;
            }                                           
            base.WndProc(ref m);
        }
    }

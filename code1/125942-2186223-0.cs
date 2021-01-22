    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m) {
            // Catch WM_SYSCOMMAND, SC_MINIMIZE
            if (m.Msg == 0x112 && m.WParam.ToInt32() == 0xf020) {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                this.BeginInvoke(new Action(() => this.Show()));
                return;
            }
            base.WndProc(ref m);
        }
    }

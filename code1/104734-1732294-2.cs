    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            this.showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        }
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used
        protected override void SetVisibleCore(bool value) {
            if (!allowVisible) {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (!allowClose) {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            allowVisible = true;
            Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            allowClose = true;
            Application.Exit();
        }
    }

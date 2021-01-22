    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            this.showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        }
        bool mAllowVisible;     // ContextMenu's Show command used
        bool mAllowClose;       // ContextMenu's Exit command used
        bool mLoadFired;        // Form was shown once
        protected override void SetVisibleCore(bool value) {
            if (!mAllowVisible) {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (!mAllowClose) {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            mAllowVisible = true;
            mLoadFired = true;
            Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            mAllowClose = mAllowVisible = true;
            if (!mLoadFired) Show();
            Close();
        }
    }

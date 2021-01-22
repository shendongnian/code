    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
        }
        private UserControl mActivePanel;
        void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            UserControl newPanel = null;
            switch (e.Node.Index) {
                case 0: newPanel = new UserControl1(); break;
                case 1: newPanel = new UserControl2(); break;
                // etc...
            }
            if (newPanel != null) {
                if (mActivePanel != null) {
                    mActivePanel.Dispose();
                    this.Controls.Remove(mActivePanel);
                }
                newPanel.Dock = DockStyle.Fill;
                this.Controls.Add(newPanel);
                this.Controls.SetChildIndex(newPanel, 0);
                mActivePanel = newPanel;
            }
        }
    }

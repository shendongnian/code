    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private bool prefixSeen;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (prefixSeen) {
                if (keyData == (Keys.Alt | Keys.Control | Keys.P)) {
                    MessageBox.Show("Got it!");
                }
                prefixSeen = false;
                return true;
            }
            if (keyData == (Keys.Alt | Keys.Control | Keys.K)) {
                prefixSeen = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public partial class Form1 : Form, IMessageFilter {
        public Form1()  {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
        }
        bool mRepeating;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.F) && !mRepeating) {
                mRepeating = true;
                Console.WriteLine("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == 0x101) mRepeating = false;
            return false;
        }
    }

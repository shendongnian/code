      public partial class Form1 : Form {
        public static Form1 MainForm { get; private set; }
        public Form1() {
          InitializeComponent();
          MainForm = this;
        }
        public void RunClickMethod() {
          button1.PerformClick();
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
          MainForm = null;
          base.OnFormClosing(e);
        }
      }

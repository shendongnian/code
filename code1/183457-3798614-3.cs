    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            Properties.Settings.Default.Setting[0] = DateTime.Now.ToString();
            Properties.Settings.Default.Save();
            base.OnFormClosing(e);
        }
    }

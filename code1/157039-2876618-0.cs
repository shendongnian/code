    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e) {
            if (Properties.Settings.Default.Form1Size.Width > 0) {  // Valid?
                this.Size = Properties.Settings.Default.Form1Size;
                this.Location = Properties.Settings.Default.Form1Location;
            }
            base.OnLoad(e);
        }
        protected override void OnLocationChanged(EventArgs e) {
            if (this.WindowState == FormWindowState.Normal) 
                Properties.Settings.Default.Form1Location = this.Location;
            base.OnLocationChanged(e);
        }
        protected override void OnResize(EventArgs e) {
            if (this.WindowState == FormWindowState.Normal)
                Properties.Settings.Default.Form1Size = this.Size;
            base.OnResize(e);
        }
        protected override void OnFormClosed(FormClosedEventArgs e) {
            Properties.Settings.Default.Save();
            base.OnFormClosed(e);
        }
    }

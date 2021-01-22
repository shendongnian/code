      public partial class Form1 : Form {
        private Timer mTimer;
        public Form1() {
          InitializeComponent();
          mTimer = new Timer();
          mTimer.Interval = 200;
          mTimer.Tick += mTimer_Tick;
          mTimer.Enabled = true;
        }
        private void mTimer_Tick(object sender, EventArgs e) {
          if (!this.DesktopBounds.Contains(Cursor.Position)) this.Close();
        }
      }

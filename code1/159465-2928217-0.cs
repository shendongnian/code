    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Opacity = 0.99;        // Avoid flicker
            mFadeTimer.Interval = 15;
            mFadeTimer.Tick += new EventHandler(mFadeTimer_Tick);
            mMouseTimer.Interval = 200;
            mMouseTimer.Tick += new EventHandler(mMouseTimer_Tick);
            mMouseTimer.Enabled = true;
        }
        void mMouseTimer_Tick(object sender, EventArgs e) {
            if (this.Bounds.Contains(Control.MousePosition)) {
                if (mFade <= 0) { mFade = 1; mFadeTimer.Enabled = true; }
            }
            else {
                if (mFade >= 0) { mFade = -1; mFadeTimer.Enabled = true; }
            }
        }
        void mFadeTimer_Tick(object sender, EventArgs e) {
            double opaq = this.Opacity + mFade * 0.05;
            if (opaq >= 0.99) { opaq = 0.99; mFadeTimer.Enabled = false; }
            if (opaq <= 0.15) { opaq = 0.15; mFadeTimer.Enabled = false; }
            this.Opacity = opaq;
        }
        private Timer mFadeTimer = new Timer();
        private Timer mMouseTimer = new Timer();
        private int mFade = 0;
    }

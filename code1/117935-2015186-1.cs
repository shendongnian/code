    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }
        private bool mEntered;
        void timer1_Tick(object sender, EventArgs e) {
            Point pos = this.PointToClient(Cursor.Position);
            bool entered = this.ClientRectangle.Contains(pos);
            if (entered != mEntered) {
                mEntered = entered;
                if (!entered) {
                    // Do your leave stuff
                    //...
                }
            }
        }
    }

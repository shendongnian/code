    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            timer1.Interval = SystemInformation.DoubleClickTime;
            timer1.Tick += delegate { timer1.Enabled = false; };
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (timer1.Enabled) {
                timer1.Enabled = false;
                // Do double-click stuff
                //...
            }
            else {
                timer1.Enabled = true;
                // Do single-click stuff
                //...
            }
        }
    }

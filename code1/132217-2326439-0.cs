      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          timer1.Interval = 16;
          timer1.Tick += new EventHandler(timer1_Tick);
          panel1.BackColor = Color.Aqua;
          mWidth = panel1.Width;
    
        }
        int mDir = 0;
        int mWidth;
        void timer1_Tick(object sender, EventArgs e) {
          int width = panel1.Width + mDir;
          if (width >= mWidth) {
            width = mWidth;
            timer1.Enabled = false;
          }
          else if (width < Math.Abs(mDir)) {
            width = 0;
            timer1.Enabled = false;
            panel1.Visible = false;
          }
          panel1.Width = width;
        }
    
        private void button1_Click(object sender, EventArgs e) {
          mDir = panel1.Visible ? -5 : 5;
          panel1.Visible = true;
          timer1.Enabled = true;
        }
      }

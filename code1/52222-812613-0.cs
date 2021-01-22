    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int iCounter = 0;
        private void Draw()
        {
            // ....
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            iCounter++;
            if(iCounter == 399)
            {
                iCounter = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            timer1.Enabled = true;
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }
    }

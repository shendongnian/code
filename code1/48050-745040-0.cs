    public partial class Form1 : Form
    {
        public bool TimeToHide { get; private set; }
        public bool IsHidden { get; private set; }
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsHidden) 
            { 
                Cursor.Show(); 
                TimeToHide = false; 
                IsHidden = false; 
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.TimeToHide = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimeToHide && !IsHidden)
            {
                Cursor.Hide();
                IsHidden = true;
            }
        }
    }

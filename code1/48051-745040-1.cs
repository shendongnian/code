    public partial class Form1 : Form
    {
        public TimeSpan TimeoutToHide { get; private set; }
        public DateTime LastMouseMove { get; private set; }
        public bool IsHidden { get; private set; }
        public Form1()
        {
            InitializeComponent();
            TimeoutToHide = TimeSpan.FromSeconds(5);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            LastMouseMove = DateTime.Now;
            if (IsHidden) 
            { 
                Cursor.Show(); 
                IsHidden = false; 
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elaped = DateTime.Now - LastMouseMove;
            if (elaped >= TimeoutToHide && !IsHidden)
            {
                Cursor.Hide();
                IsHidden = true;
            }
        }
    }

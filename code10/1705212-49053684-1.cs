      public partial class Form1 : Form
    {
        Timer t;
        public Form1()
        {
            InitializeComponent();
            t = new Timer();
            //A single tick represents one hundred nanoseconds or one ten-millionth of a second. There are 10,000 ticks in a millisecond, or 10 million ticks in a second.
            //t.Interval = (int)(100 / TimeSpan.TicksPerMillisecond);//0.01 ms
            t.Interval = 2000;//2 seconds
            t.Tick += T_Tick;
            t.Enabled = false;
            this.MouseClick += Form1_MouseClick;
        }
        private void T_Tick(object sender, EventArgs e)
        {
            //Action...
            
            //If you want the action to occur once then uncomment this line
            //T.Enabled = false;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    t.Enabled = true;
                    break;
                default:
                    t.Enabled = false;
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }

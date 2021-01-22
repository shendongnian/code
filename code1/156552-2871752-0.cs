    public partial class Form1 : Form
    {
        int m_counter = 0;
        public Form1()
        {
            InitializeComponent();
            // Attach Mouse Wheel Event
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Refresh Slow Timer
            slowTimer.Enabled = false;
            slowTimer.Stop();
            slowTimer.Interval = 150;
            slowTimer.Start();
            slowTimer.Enabled = true;
            // Incremenet counter
            m_counter++;
            // Start Fast Timer
            if (fastTimer.Enabled == false)
            {
                fastTimer.Enabled = true;
                fastTimer.Interval = 50;
                fastTimer.Start();
            }
            // If this returns true call
            // the fast scroll implementation
            if (m_counter > 4)
            {
                Console.WriteLine("Quick Method Called");
                m_counter = 0;
                fastTimer.Stop();
                slowTimer.Enabled = false;
                slowCheckTimer.Stop();
                slowCheckTimer.Interval = 200;
                slowCheckTimer.Start();
                slowCheckTimer.Enabled = true;
            }
        }
        private void slowTimer_Tick(object sender, EventArgs e)
        {            
            if (slowCheckTimer.Enabled == false)
            {
                Console.WriteLine("Slow Method Called");
            }
            slowTimer.Enabled = false;
        }
        private void fastTimer_Tick(object sender, EventArgs e)
        {
            fastTimer.Enabled = false;            
            m_counter = 0;
            fastTimer.Stop();
        }
        private void slowCheckTimer_Tick(object sender, EventArgs e)
        {            
            slowCheckTimer.Stop();
            slowCheckTimer.Enabled = false;
        }
    }

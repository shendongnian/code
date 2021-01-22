    public partial class Form1 : Form
    {
        private Timer timer;
        private int startPosX;
        private int startPosY;
        public Form1()
        {
            InitializeComponent();
            // We want our window to be the top most
            TopMost = true;
            // Pop doesn't need to be shown in task bar
            ShowInTaskbar = false;
            // Create and run timer for animation
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += timer_Tick;
        }
        protected override void OnLoad(EventArgs e)
        {
            // Move window out of screen
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            SetDesktopLocation(startPosX, startPosY);
            base.OnLoad(e);
            // Begin animation
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 5; 
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
                timer.Stop();
            else
               SetDesktopLocation(startPosX, startPosY);
        }
    }

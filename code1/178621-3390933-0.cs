    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            _rate = new Random().Next(1, 10);
    
            _timer = new Timer() { Interval = 100, Enabled = true };
            _timer.Tick += new EventHandler(timer_Tick);
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.pictureBox1.Location.X > (this.Size.Width - this.pictureBox1.Size.Width))
            {
                return;
            }
    
            Point newLocation = this.pictureBox1.Location;
            newLocation.X += _rate;
            this.pictureBox1.Location = newLocation;
        }
        
        private int _rate;
        private Timer _timer;
    }

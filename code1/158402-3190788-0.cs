    public partial class Form1 : Form
    {
        int Radious = 5;
        Random _rnd = new Random();
        Timer T = new Timer();
        int InterVal = 1000;
        MouseEventArgs MEA = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            T.Tick += (O, E) =>
            {
                StartSpray();
            };
            this.MouseDown += (O, E) =>
            {
                MEA = E;
                T.Interval = InterVal;
                T.Start();
                
             };
            this.MouseUp += (O, E) =>
            {
                T.Stop();
            };
        }
        private void StartSpray()
        {
            Point P = DrawPoint(Radious, MEA.X, MEA.Y);
            // Draw the point on any graphics area you can add the color or anything else
        }
        private Point DrawPoint(int Radious, int StatX, int StartY)
        {
            double theta = _rnd.NextDouble() * (Math.PI * 2);
            double r = _rnd.NextDouble() * Radious;
            Point P = new Point { X = StatX + Convert.ToInt32(Math.Cos(theta) * r), Y = StartY + Convert.ToInt32(Math.Sin(theta) * r) };
            return P;
        }      
    }

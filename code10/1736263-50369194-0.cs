    public partial class Form1 : Form
    {
        private List<Point> _points; // List of Points
        private Timer _timer; // The Timer
        private Graphics _g; // The Graphics object which is responsible for drawing the anything onto the Form
    
        public Form1()
        {
            _points = new List<Point>();
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            InitializeComponent();
            _g = CreateGraphics();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            _timer.Start();
        }
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            _points.Add(pictureBox1.Location); // Add the current location to the List
            // Invoke the GUI Thread to avoid Exceptions
            pictureBox1.Invoke(new Action(() =>
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y + 2);
            }));
            Pen blackPen = new Pen(Color.Black, 3);
            Invoke(new Action(() =>
            {
                for (int i = 1; i < _points.Count; i++) // Start at 1 so if you hav less than 2 points it doesnt draw anything
                {
                    _g.DrawLine(blackPen, _points[i - 1], _points[i]);
                }
            }));
        }
    }

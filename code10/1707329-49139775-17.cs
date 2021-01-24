    interface IObject
    {
        SizeF Dimension { get; }
        PointF Position { get; set; }
        void Render(Graphics g, int x, int y);
    }
    class Block : IObject
    {
        public PointF Position { get; set; }
        public SizeF Dimension { get; set; }
        public void Render(Graphics g, int x, int y)
        {
            g.DrawRectangle(
                Pens.DarkCyan,
                Position.X + x - Dimension.Width / 2,
                Position.Y + y - Dimension.Height / 2,
                Dimension.Width,
                Dimension.Height);
        }
    }
    public partial class frmPaintOnForm : Form
    {
        private Timer _timer = new Timer();
        private IObject _currentObject;
        private List<IObject> _objects = new List<IObject> {
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(10, 0), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(20, 0), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(20,10), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(20,20), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(20,30), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF(10,30), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0,30), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0,20), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0,20), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(55,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(60,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(65,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(60,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(55,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,50) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,55) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,60) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,65) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,60) },
            new Block{ Position = new PointF( 0, 0), Dimension = new SizeF(50,55) },
        };
        private int _index;
        public frmPaintOnForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _timer.Interval = 17;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Select the next object by cycling through the object list and trigger drawing
            _currentObject = _objects[_index];
            _index = (_index + 1) % _objects.Count;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_currentObject != null) {
                int x = ClientSize.Width / 2;
                int y = ClientSize.Height / 2;
                _currentObject.Render(e.Graphics, x, y);
            }
        }
    }

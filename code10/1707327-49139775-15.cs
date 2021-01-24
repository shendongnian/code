    interface IObject
    {
        Tuple<float, float> Dimension { get; }
        Tuple<float, float> Position { get; set; }
        void Render(Graphics g, int x, int y);
    }
    class Block : IObject
    {
        public Tuple<float, float> Dimension { get; set; }
        public Tuple<float, float> Position { get; set; }
        public void Render(Graphics g, int x, int y)
        {
            g.DrawRectangle(
                Pens.DarkCyan,
                Position.Item1 + x - Dimension.Item1 / 2,
                Position.Item2 + y - Dimension.Item2 / 2,
                Dimension.Item1,
                Dimension.Item2);
        }
    }
    public partial class frmPaintOnForm : Form
    {
        private Timer _timer = new Timer();
        private IObject _currentObject;
        private List<IObject> _objects = new List<IObject> {
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(10,0), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(20,0), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(20,10), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(20,20), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(20,30), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(10,30), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,30), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,20), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,20), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(55,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(60,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(65,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(60,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(55,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,50) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,55) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,60) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,65) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,60) },
            new Block{ Position=new Tuple<float, float>(0,0), Dimension=new Tuple<float, float>(50,55) },
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

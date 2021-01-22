        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        bool mouseDown = false;
        Point mouseDownPoint = Point.Empty;
        Point mousePoint = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown = true;
            mousePoint = mouseDownPoint = e.Location;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mousePoint = e.Location;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (mouseDown)
            {
                Region r = new Region(this.ClientRectangle);
                Rectangle window = new Rectangle(
                    Math.Min(mouseDownPoint.X, mousePoint.X),
                    Math.Min(mouseDownPoint.Y, mousePoint.Y),
                    Math.Abs(mouseDownPoint.X - mousePoint.X),
                    Math.Abs(mouseDownPoint.Y - mousePoint.Y));
                r.Xor(window);
                e.Graphics.FillRegion(Brushes.Red, r);
                Console.WriteLine("Painted: " + window);
            }
        }

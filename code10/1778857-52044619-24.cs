    public partial class Grid : Panel
    {
        public Grid()
        {
            InitializeComponent();
            GridColor = Color.DarkMagenta;
            HandleSize = 4;
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }
        int RowCount { get; set; }
        int ColCount { get; set; }
        Color GridColor { get; set; }
        int HandleSize { get; set; }
        List<int> Xs { get; set; }
        List<int> Ys { get; set; }
        public void Init(int cols, int rows)
        {
            RowCount = rows;
            ColCount = cols;
            Xs = new List<int>();
            Ys = new  List<int>();
            float w = 1f * Width / cols;
            float h = 1f * Height / rows;
            for (int i = 0; i <= cols; i++) Xs.Add((int)(i * w));
            for (int i = 0; i <= rows; i++) Ys.Add((int)(i * h));
            // draw inside the panel only
            if (Xs[cols] == Width) Xs[cols]--;
            if (Ys[rows] == Height) Ys[cols]--;
        }
        public void Init(int cols, int rows, Size sz)
        {
            Size = sz;
            Init(cols, rows);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using (Pen pen = new Pen(GridColor))
            {
                foreach (int x in Xs) pe.Graphics.DrawLine(pen, x, 0, x, Height);
                foreach (int y in Ys) pe.Graphics.DrawLine(pen, 0, y, Width, y);
            }
        }
        private Point mDown = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (Cursor != Cursors.Default) mDown = e.Location;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // distances
            var dx = Xs.Select(x => Math.Abs(x - e.X));
            var dy = Ys.Select(y => Math.Abs(y - e.Y));
            // smallest distance
            int mx = dx.Min();
            int my = dy.Min();
            // grid index
            int ix = dx.ToList().IndexOf(mx);
            int iy = dy.ToList().IndexOf(my);
            if (e.Button.HasFlag(MouseButtons.Right))
            {   // move the grid with the right mouse button
                Location = new Point(Left + e.X - mDown.X, Top + e.Y - mDown.Y);
            }
            else if (!e.Button.HasFlag(MouseButtons.Left))
            {   // if we are close enough set cursor
                Cursor = Cursors.Default;
                if (mx < HandleSize) Cursor = Cursors.SizeWE;
                if (my < HandleSize) Cursor = Cursors.SizeNS;
                if (mx < HandleSize && my < HandleSize) Cursor = Cursors.SizeAll;
            }
            else
            {   // else move grid line(s)
                if (Cursor == Cursors.SizeWE  || Cursor == Cursors.SizeAll)
                   Xs[ix] += e.X - mDown.X;
                if (Cursor == Cursors.SizeNS  || Cursor == Cursors.SizeAll) 
                   Ys[iy] +=  e.Y - mDown.Y;
                Invalidate();
                mDown = e.Location;
                // restore order in case we overshot
                Xs = Xs.OrderBy(x => x).ToList();
                Ys = Ys.OrderBy(x => x).ToList();
            }
        }
    }

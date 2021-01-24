    public class GridPanel : Panel
    {
        public GridPanel()
        {
            DoubleBuffered = true; // Speeds up drawing, e.g. when panel is resized.
            // Set default colors
            BackColor = Color.Black;
            ForeColor = Color.Green;
        }
        private int _lenghtBetweenGridPoints = 20;
        public int LenghtBetweenGridPoints
        {
            get { return _lenghtBetweenGridPoints; }
            set {
                if (value != _lenghtBetweenGridPoints) {
                    _lenghtBetweenGridPoints = value;
                    Invalidate(); // Redraw the grid.
                }
            }
        }
        private int _sizeGridPoints = 3;
        public int SizeGridPoints
        {
            get {
                return _sizeGridPoints;
            }
            set {
                if (value != _sizeGridPoints) {
                    _sizeGridPoints = value;
                    Invalidate(); // Redraw the grid.
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // e.Graphics.Clear(Color.Black); Not necessary. We use the BackColor of the panel.
            if (LenghtBetweenGridPoints > 0 && SizeGridPoints > 0) {
                using (var brush = new SolidBrush(ForeColor)) { // We use the ForeColor of the panel.
                    for (int x = LenghtBetweenGridPoints; x < Width; x += LenghtBetweenGridPoints) {
                        for (int y = LenghtBetweenGridPoints; y < Height; y += LenghtBetweenGridPoints) {
                            e.Graphics.FillEllipse(brush, x, y, SizeGridPoints, SizeGridPoints);
                        }
                    }
                }
            }
        }
    }

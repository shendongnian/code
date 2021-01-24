    public class GridPanel : Panel
    {
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
            e.Graphics.Clear(Color.Black);
            for (int x = LenghtBetweenGridPoints; x < Width; x += LenghtBetweenGridPoints) {
                for (int y = LenghtBetweenGridPoints; y < Height; y += LenghtBetweenGridPoints) {
                    e.Graphics.FillEllipse(Brushes.Green, x, y, SizeGridPoints, SizeGridPoints);
                }
            }
        }
    }

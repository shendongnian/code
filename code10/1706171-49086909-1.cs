        private Color _lineColor = Color.FromArgb(50, 200, 0, 100);
                
        public Color LineColor
        {
            get { return _lineColor; }
            set {
                
                _lineColor = value == Color.Empty ? Color.FromArgb(50, 200, 0, 100): value;
            }
        }

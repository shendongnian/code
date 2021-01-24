        private Color _lineColor = Color.FromArgb(31, 0, 0, 0);
        [Browsable(true)]
        [Category("Custom Colors")]
        [Description("Gets or sets the line color if not focused.")]
        public Color LineColor
        {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

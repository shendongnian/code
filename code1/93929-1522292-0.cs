        [DefaultValue(typeof(Color), "0xFF0000")]
        public Color LineColor
        {
                get { return lineColor; }
                set { lineColor = value; Invalidate ( ); }
        }

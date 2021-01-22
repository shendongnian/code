        public double v{set;get;}
        public int v100
        {
            set { v = value / 100D; }
            get { return (int)(v* 100D); }
        }

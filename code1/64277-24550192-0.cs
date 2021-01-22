    class MyImage : Image {
        private Thickness thickness;
        public double MarginLeft {
            get { return Margin.Left; }
            set { thickness = Margin; thickness.Left = value; Margin = thickness; }
        }
    }

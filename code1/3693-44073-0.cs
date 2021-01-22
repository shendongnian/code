    class MyClass
    {
        Color lineColor = SystemColors.InactiveBorder;
        
        [DefaultValue(true)]
        public Color LineColor {
            get {
                return lineColor;
            }
            set {
                lineColor = value;
            }
        }
    }

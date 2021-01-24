    public class ColorData
    {
        public ColorData(Brush color, String colorName)
        {
            ColorBrush = color;
            ColorText = colorName;
        }
        public Brush ColorBrush { get; set; }
        public string ColorText { get; set; }
    } 

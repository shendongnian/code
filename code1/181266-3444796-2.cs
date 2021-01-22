    public enum MeasurementType
    {
        Each,
        [DisplayText("Lineal Metres")]
        LinealMetre,
        [DisplayText("Square Metres")]
        SquareMetre,
        [DisplayText("Cubic Metres")]
        CubicMetre,
        [DisplayText("Per 1000")]
        Per1000,
        Other
    }
    public class DisplayText : Attribute
    {
        public DisplayText(string Text)
        {
            this.text = Text;
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }

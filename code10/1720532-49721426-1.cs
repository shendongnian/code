    public class ShadedColorExtension : MarkupExtension
    {
        public Color BaseColor { get; set; }
        public double Lighter { get; set; }
        public double Darker { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Lighter > 0d)
            {
                return BaseColor.MakeLighter(Lighter);
            }
            if (Darker > 0d)
            {
                return BaseColor.MakeDarker(Darker);
            }
            return BaseColor;
        }
    }

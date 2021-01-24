    [MarkupExtensionReturnType(typeof(Color))]
    public class BrightnessExtension : MarkupExtension
    {
        [ConstructorArgument("color")]
        public Color Color { get; set; }
        [ConstructorArgument("brightness")]
        public double Brightness { get; set; }
        public BrightnessMarkupExtension() { }
 
        public BrightnessMarkupExtension(Color color, double brightness)
        {
            Color = color;
            Brightness = brightness;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return //<do something with Color and Brightness here>;
        }
    }

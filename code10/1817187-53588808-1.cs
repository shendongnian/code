    public class ColorTransform
    {
        public static float GetFactor(DependencyObject obj)
        {
            return (float)obj.GetValue(FactorProperty);
        }
        public static void SetFactor(DependencyObject obj, float value)
        {
            obj.SetValue(FactorProperty, value);
        }
        public static readonly DependencyProperty FactorProperty =
            DependencyProperty.RegisterAttached("Factor", typeof(float), typeof(ColorTransform), 
                new FrameworkPropertyMetadata(1.0F,
                    FrameworkPropertyMetadataOptions.AffectsRender));
    }

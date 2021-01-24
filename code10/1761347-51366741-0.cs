    public class PassParamBrush{
    public static DependencyProperty BorderBrushProperty = DependencyProperty.RegisterAttached
    (
     "BorderBrush",
     typeof(SolidColorBrush),
     typeof(PassParamBrush),
     new PropertyMetadata(null)
    );
    public static SolidColorBrush GetBorderBrush(DependencyObject target)
    {
        return (SolidColorBrush)target.GetValue(BorderBrushProperty);
    }
    public static void SetBorderBrush(DependencyObject target, ImageSource value)
    {
        target.SetValue(BorderBrushProperty, value);
    }

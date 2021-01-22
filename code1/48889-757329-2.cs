    public class AutoGreyableImage : Image
    {
    	public static readonly DependencyProperty CustomProperty = DependencyProperty.Register("Custom",
    		typeof(string),
    		typeof(AutoGreyableImage));
    
    	public string Custom
    	{
    		get { return GetValue(CustomProperty) as string; }
    		set { SetValue(CustomProperty, value); }
    	}
    }

    [assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
    namespace CustomSliderColor.iOS
    {
    	public class CustomSliderRenderer : SliderRenderer
    	{
    		protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
    		{
    			base.OnElementChanged(e);
    
    			if (Control != null)
    			{
                    const string colorSlider = "#008000";
    				Control.MaximumTrackTintColor = Color.FromHex(colorSlider).ToUIColor();
    				Control.MinimumTrackTintColor = Color.FromHex(colorSlider).ToUIColor();
    				Control.ThumbTintColor = Color.FromHex(colorSlider).ToUIColor();
    			}
    		}
    	}
    }

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
    				Control.MaximumTrackTintColor = Color.FromHex(CustomSlider.SliderColorHexValue).ToUIColor();
    				Control.MinimumTrackTintColor = Color.FromHex(CustomSlider.SliderColorHexValue).ToUIColor();
    				Control.ThumbTintColor = Color.FromHex(CustomSlider.SliderColorHexValue).ToUIColor();
    			}
    		}
    	}
    }

    [assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
    namespace ForteMultiplataform.UWP
    {
        public class CustomSliderRenderer : SliderRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    Windows.UI.Xaml.Style sliderStyle = (Windows.UI.Xaml.Style)Windows.UI.Xaml.Application.Current.Resources["styledSlider"];
                    Control.Style = sliderStyle;
                }
            }
        }
    }

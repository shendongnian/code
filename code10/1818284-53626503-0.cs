    public class Slider_iOS : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            Control.ThumbTintColor = UIColor.Clear; //add here
            SetNativeControl(new MySlideriOS());
        }
    }

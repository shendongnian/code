    slider.AddTarget(this,new Selector("SliderValueChange:"),UIControlEvent.ValueChanged);
    slider.AddTarget(this,new Selector("SliderTouchStart:"), UIControlEvent.TouchDown);
    slider.AddTarget(this,new Selector("SliderTouchEnded:"), UIControlEvent.TouchUpInside);
    [Export("SliderValueChange:")]
    public void SliderValueChange(UISlider sender)
     {
        Console.WriteLine(sender.Value);
     }
    [Export("SliderTouchStart:")]
    public void SliderTouchStart(UISlider sender)
     {
        Console.WriteLine("start");
     }
    [Export("SliderTouchEnded:")]
    public void SliderTouchEnded(UISlider sender)
     {
        Console.WriteLine("end");
     }

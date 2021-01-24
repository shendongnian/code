    slider.AddTarget(this, new Selector("SliderValueChanged:"), UIControlEvent.ValueChanged);
    [Export("SliderValueChanged:")]
    public void SliderValueChanged(UISlider sender)
     {
        // do something you want
        Console.WriteLine(sender.Value); 
     }

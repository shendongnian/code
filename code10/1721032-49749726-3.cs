    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
    	base.FillTargetFactories(registry);
    	registry.RegisterPropertyInfoBindingFactory(
    		typeof(FixedMvxUISliderValueTargetBinding),
    		typeof(UISlider),
    		nameof(UISlider.Value));
    }

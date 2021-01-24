    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
        base.FillTargetFactories(registry);
    
        registry.RegisterCustomBindingFactory<UIControl>(
            "EditingDidEnd",
            view =>
                new MvxUITextFieldEditingDidBeginTargetBinding(view));
    }

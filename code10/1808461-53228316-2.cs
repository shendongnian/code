    protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
    {
        base.FillTargetFactories(registry);
        registry.RegisterFactory(new MvxCustomBindingFactory<SwitchRightText>("Text", srt => new TextSwitchRightTextTargetBinding(srt)));
    }

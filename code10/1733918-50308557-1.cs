    // using Abp.Configuration.Startup;
    public override void PreInitialize()
    {
        Configuration.ReplaceService<ISettingStore, MySettingStore>(DependencyLifeStyle.Transient);
    }

    public override void Init()
    {
        base.Error+=new EventHandler(MvcApplication_Error);
        base.Init();
    }

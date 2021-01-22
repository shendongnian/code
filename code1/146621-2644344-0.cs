    protected override void OnRender(EventArgs e)
    {
       // do something
       base.OnRender(e);
       // just OnRender(e); will bring a StakOverFlowException
       // because it's equal to this.OnRender(e);
    }

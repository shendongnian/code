    protected override void OnLoad(EventArgs e)
    {
        tb.TextChanged += SomeHandler;
        if (!IsPostback)
        {
            tb.TextChanged(this, e);
        }
    }
    void SomeHandler(object sender, EventArgs e) { ... }

    protected override void CreateChildControls()
    {
       Controls.Add(_control1);
       Controls.Add(_control2);
    }     
    protected override void OnPreRender(EventArgs e)
    {
       _control1.Visible = !RenderControl2;
       _control2.Visible = RenderControl2;
    }

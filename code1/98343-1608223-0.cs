    protected void AlwaysPreRender( object sender, EventArgs e )
    {
        if ( /* some condition */ )
        {
            this.Visible = true;
        }
        // else leave Visible as it was
    }
    protected override void OnLoad(EventArgs e)
    {
        Page.PreRender += this.AlwaysPreRender;
    }

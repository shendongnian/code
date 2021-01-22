    protected override void OnMouseLeave(EventArgs e)
    {
    
        if(this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
             return;
        else
        {
            base.OnMouseLeave(e);
        }
    }

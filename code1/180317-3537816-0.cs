    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        if (!this.selectionSet)
        {
            this.selectionSet = true;
            if ((this.SelectionLength == 0) && (Control.MouseButtons == MouseButtons.None))
            {
                base.SelectAll();
            }
        }
    }

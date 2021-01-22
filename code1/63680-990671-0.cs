    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
        {
            Control next = this.GetNextControl(this.ActiveControl, true);
            if (next == null)
            {
                next = this.GetNextControl(this, true);
            }
    
            next.Focus();
            e.Handled = true;
        }
    
        base.OnKeyUp(e);
    }

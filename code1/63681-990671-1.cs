    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
        {
           Control activeControl = this.ActiveControl;
           
           if(activeControl == null)
           {
                activeControl = this;
           }
           this.SelectNextControl(activeControl, true, true, true, true);
           e.Handled = true;
        }
    
        base.OnKeyUp(e);
    }

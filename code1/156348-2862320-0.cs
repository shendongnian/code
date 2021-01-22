    foreach (object ctrl in this.pnlControl.Controls)
    {
        ToolTip tipControl = ctrl as ToolTip;
        if (tipControl != null)
        {
            tipControl.Active=false;
        }
    }

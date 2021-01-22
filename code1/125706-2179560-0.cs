    protected void DisableSQRControls(Control control)
    {
     foreach(var webControl in control.Controls.OfType<WebControl>())
     {
      webControl.Enabled = false;
      DisableSQRControls( webControl );
     }
    }

    protected void DisableButtons(Control root)
    {
         foreach (Control ctrl in root.Controls)
         {
              if (ctrl is Button)
              {
                  ((WebControl)ctrl).Enabled = false;
              }
              else
              {
                  if (ctrl.Controls.Count > 0)
                  {
                       DisableButtons(ctrl);
                  }
              }
         }
    }

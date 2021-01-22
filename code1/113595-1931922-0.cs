    private void addEventsToAllControls(Control ctrl)
    {
      foreach (Control control in ctrl.Controls)
      {
        control.MouseEnter += new EventHandler(this.control_MouseEnter);
        control.MouseLeave += new EventHandler(this.control_MouseLeave);
        if (control.HasChildren)
          addEventsToAllControls(control);
        if (control is MenuStrip)
        {
          MenuStrip ms = control as MenuStrip;
          AddEventsToAllToolStripItems(ms.Items);
        }
        else if (control is ToolStrip)
        {
          ToolStrip ts = control as ToolStrip;
          AddEventsToAllToolStripItems(ts.Items);
        }
      }
    }

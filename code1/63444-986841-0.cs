    protected override void OnLoad()
    {
       HookupMouseEnterEvents(this);
    }
    
    private void HookupMouseEnterEvents(Control control)
    {
       foreach (Control childControl in control.Controls)
       {
          childControl.MouseEnter += new MouseEventHandler(mouseEnter);
    
          // Recurse on this child to get all of its descendents.
          HookupMouseEnterEvents(childControl);
       }
    }

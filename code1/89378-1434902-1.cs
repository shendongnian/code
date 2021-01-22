    if (e.KeyCode == Keys.C && e.Modifiers == (Keys.Control | Keys.Shift))
    {
        //Do work (if Ctrl-Shift-C is pressed, but not if Alt is pressed as well)
    }
    else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
    {
        //Paste (if Ctrl is only modifier pressed)
    }

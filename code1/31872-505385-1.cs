    protected void DisableControls(Control parent, bool State) {
        foreach(Control c in parent.Controls) {
            if (c is DropDownList) {
                ((DropDownList)(c)).Enabled = State;
            }
    
            DisableControls(c);
        }
    }

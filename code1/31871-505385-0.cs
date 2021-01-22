    protected void DisableControls(Control parent) {
        foreach(Control c in parent.Controls) {
            if (c is DropDownList) {
                ((DropDownList)(c)).Enabled = false;
            }
    
            DisableControls(c);
        }
    }

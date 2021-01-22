    // This is the recursive version
    public void LoopControl(Control parent) {
        foreach (Control control in parent) {
            // do stuff
            LoopControl(control);
        }
    }
    // And then
    LoopControl(Page);

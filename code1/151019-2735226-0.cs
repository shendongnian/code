    void iterateControls(Control ctrl)
    {
        foreach(Control c in ctrl.Controls)
        {
            iterateControls(c);
        }
    }

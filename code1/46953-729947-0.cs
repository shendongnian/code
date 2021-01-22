    bool updatingCheckbox = false;
    void updateCheckBox()
    {
        updatingCheckBox = true;
        checkbox.Checked = true;
        updatingCheckBox = false;
    }
    void checkbox_CheckedChanged( object sender, EventArgs e )
    {
        if (!updatingCheckBox)
            PerformActions()
    }

    public void Combobox_ValueChanged(object sender, EventArgs e) {
        if (!AskUserIfHeIsSureHeWantsToChangeTheValue())
        {
            // Set previous value
            return;
        }
        // perform rest of onChange code
    }

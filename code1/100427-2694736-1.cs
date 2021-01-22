    private void buttonLoadDefaultSettings_Click(object sender, EventArgs e)
    {
        FooSettings.Default.Reset();
        DataGridFoo.Rows.Clear();
        // Use the default values since we know that the user settings 
        // were just reset.
        foreach (SettingsProperty sp in FooSettings.Default.Properties)
        {
            DataGridFoo.Rows.Add(sp.Name, sp.DefaultValue);
        }
    }

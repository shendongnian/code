    private void LoadSettings()
    {
        textBoxOutput.Text = (String)Application.UserAppDataRegistry.GetValue("SomeName", String.Empty);
    }
    private void SaveSettings()
    {
        Application.UserAppDataRegistry.SetValue("SomeName", textBoxOutput.Text);
    }

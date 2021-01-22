    public SettingsResults GetNewSettings()
    {
        if(this.ShowDialog() == DialogResult.Ok)
        {
             return new SettingsResult { ... };
        }
        else
        {
             return null;
        }
    }

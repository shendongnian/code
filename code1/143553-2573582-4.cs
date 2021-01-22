    public MyControl : IMySettableSettingsControl 
    {
        public void ApplySettings(Dictionary<string, object> settings) 
        {
            if (settings.Key.Contains("TextboxContents"))
                someTextBox.Text = (string) settings["TextboxContents"];
            if (settings.Key.Contains("Height"))
                this.Height = (double) settings["Height"];
            ((IMySettableSettingsControl) someChildControl).ApplySettings(settings["MyChildControl"])
        }
        public Dictionary<string, object> RetrieveSettings()
        {
            Dictionary<string, object> localSettings = new Dictionary<string, object>();
            localSettings.Add("Height", this.Height);
            localSettings.Add("TextboxContents", someTextBox.Text);
            localSettings.Add("MyChildControl", ((IMySettableSettingsControl) someChildControl).RetrieveSettings();
        }
    }

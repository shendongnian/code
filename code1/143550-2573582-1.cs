    public MyControl : IMySettableSettingsControl 
    {
        public void ApplySettings(Dictionary<string, object> settings) 
        {
            foreach (string key in settings.Keys) 
            {
                object o = settings[key];
                // 'o' now contains an individual setting, apply it to whatever property
            }
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

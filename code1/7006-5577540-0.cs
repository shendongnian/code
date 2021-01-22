    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace CustomForm
    {
      public class MyCustomForm : Form
      {
        private ApplicationSettingsBase _appSettings = null;
        private string _settingName = "";
    
        public Form() : base() { }
    
        public Form(ApplicationSettingsBase settings, string settingName)
          : base()
        {
          _appSettings = settings;
          _settingName = settingName;
    
          this.Load += new EventHandler(Form_Load);
          this.FormClosing += new FormClosingEventHandler(Form_FormClosing);
        }
    
        private void Form_Load(object sender, EventArgs e)
        {
          if (_appSettings == null) return;
    
          PropertyInfo settingProperty = _appSettings.GetType().GetProperty(_settingName);
          if (settingProperty == null) return;
    
          WindowSettings previousSettings = settingProperty.GetValue(_appSettings, null) as WindowSettings;
          if (previousSettings == null) return;
    
          previousSettings.Restore(this);
        }
    
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
          if (_appSettings == null) return;
    
          PropertyInfo settingProperty = _appSettings.GetType().GetProperty(_settingName);
          if (settingProperty == null) return;
    
          WindowSettings previousSettings = settingProperty.GetValue(_appSettings, null) as WindowSettings;
          if (previousSettings == null)
            previousSettings = new WindowSettings();
    
          previousSettings.Record(this);
    
          settingProperty.SetValue(_appSettings, previousSettings, null);
    
          _appSettings.Save();
        }
      }
    }

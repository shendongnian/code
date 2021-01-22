    class FormSettings
    {
         object Color {get, set}
    }
    
    
    class MainForm
    {
        ...
        
        void ChangeSettings(FormSettings newSettings)
        { ... }
    
        void EditPreferences_Click(...)
        {
            ...
    
            EditPreferencesForm editPreferences = new EditPreferencesForm(this.ChangeSettings)
            editPreferences.ShowDialog();
        }     
    }
    
    class EditPreferencesForm
    {
         ...
         ChangeSettingsDelegate changeSettings;
         FormSettings formSettings;
    
         void OkButton_Click(...)
         {
              changeSettings(formSettings);
         }
    }

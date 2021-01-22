    public class SettingsAuditor 
    { 
        SettingsProvider @base;
    
        public SettingsAuditor(SettingsProvider o) 
        { 
            @base = o; 
        } 
     
        public void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals) 
        { 
            // Log the property change to a file 
            @base.SetPropertyValues(context, propvals); 
        } 
    } 

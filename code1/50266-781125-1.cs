    [GeneratedCode(
    "Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator"
    ,"9.0.0.0")] 
    [CompilerGenerated]
    internal sealed class Foo : ApplicationSettingsBase
    {
        private static Settings defaultInstance = 
            ((Settings) SettingsBase.Synchronized(new Settings()));
    
        public static Settings Default
        {
            get { return defaultInstance; }
        }
    
    
        [ApplicationScopedSetting]
        [DefaultSettingValue("Shuggy")]
        [DebuggerNonUserCode]
        public string MyName
        {
            get
            {
                return (string) this["MyName"];
            }
        }
    }

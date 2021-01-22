    namespace ConsoleApplication1.Properties {
        
        
        [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
        internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
            
            private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
            
            public static Settings Default {
                get {
                    return defaultInstance;
                }
            }
            
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.Configuration.DefaultSettingValueAttribute("John Doe")]
            public string Name {
                get {
                    return ((string)(this["Name"]));
                }
                set {
                    this["Name"] = value;
                }
            }
        }
    }

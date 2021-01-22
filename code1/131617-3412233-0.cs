            /// <summary>
            /// Binds the name of the script by.
            /// </summary>
            /// <param name="control">
            /// The control.
            /// </param>
            /// <param name="scriptName">
            /// Name of the script.
            /// </param>
            public static void BindScriptByName(this Control control, string scriptName)
            {
                if (control.Page == null)
                {
                    return;
                }
    
                var sm = ScriptManager.GetCurrent(control.Page);
                if (sm == null)
                {
                    return;
                }
    
                if (sm.Scripts.Count(s => s.Name == scriptName) == 0)
                {
                    sm.Scripts.Add(new ScriptReference { Name = scriptName });
                }
            }
    
            /// <summary>
            /// Registers the script definitions.
            /// </summary>
            /// <remarks>
            /// Call this on Application_Startup in Global.asax.
            /// </remarks>
            public static void RegisterScriptDefinitions()
            {
                var jqueryScriptResDef = new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-1.4.2.min.js",
                    DebugPath = "~/Scripts/jquery-1.4.2.js",
                    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js",
                    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js"
                };
                ScriptManager.ScriptResourceMapping.AddDefinition("jQuery", jqueryScriptResDef);
    
                var jquerySuperFishMenuScriptResDef = new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery.superfishmenu.js",
                    DebugPath = "~/Scripts/jquery.superfishmenu.js",
                    CdnPath = "~/Scripts/jquery.superfishmenu.js",
                    CdnDebugPath = "~/Scripts/jquery.superfishmenu.js"
                };
                ScriptManager.ScriptResourceMapping.AddDefinition("jQuery.SuperFishMenu", jquerySuperFishMenuScriptResDef);
    
                var jqueryIdTabsScriptResDef = new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery.idTabs.min.js",
                    DebugPath = "~/Scripts/jquery.idTabs.min.js",
                    CdnPath = "~/Scripts/jquery.idTabs.min.js",
                    CdnDebugPath = "~/Scripts/jquery.idTabs.min.js",
                };
                ScriptManager.ScriptResourceMapping.AddDefinition("jQuery.idTabs", jqueryIdTabsScriptResDef);
            }

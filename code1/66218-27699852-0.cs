    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Shell32;
    using IWshRuntimeLibrary;
    using System.IO;
    
    namespace CMS.data
    {
        public class overall
        {
            public static void place_shortcut_on_desktop()
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\YourName.lnk";
                string shortcutto = System.Reflection.Assembly.GetExecutingAssembly().Location;
    
                var wsh = new IWshShell_Class();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(desktopPath) as IWshRuntimeLibrary.IWshShortcut;
                shortcut.TargetPath = shortcutto;
                shortcut.WorkingDirectory = Directory.GetParent(shortcutto).FullName;
                shortcut.Save();
            }
        }//class overall
    }

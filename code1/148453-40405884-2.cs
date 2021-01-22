     String App_Exe = "MyApp.exe";
     String App_Path = "%localappdata%;
     SetAssociation_User("myExt", App_Path + App_Exe, App_Exe);
    
     public static void SetAssociation_User(string Extension, string OpenWith, string ExecutableName)
     {
        try {
                    using (RegistryKey User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true))
                    using (RegistryKey User_Ext = User_Classes.CreateSubKey("." + Extension))
                    using (RegistryKey User_AutoFile = User_Classes.CreateSubKey(Extension + "_auto_file"))
                    using (RegistryKey User_AutoFile_Command = User_AutoFile.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
                    using (RegistryKey ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", true))
                    using (RegistryKey User_Classes_Applications = User_Classes.CreateSubKey("Applications"))
                    using (RegistryKey User_Classes_Applications_Exe = User_Classes_Applications.CreateSubKey(ExecutableName))
                    using (RegistryKey User_Application_Command = User_Classes_Applications_Exe.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
                    using (RegistryKey User_Explorer = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension))
                    using (RegistryKey User_Choice = User_Explorer.OpenSubKey("UserChoice"))
                    {
                        User_Ext.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                        User_Classes.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                        User_Classes.CreateSubKey(Extension + "_auto_file");
                        User_AutoFile_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                        ApplicationAssociationToasts.SetValue(Extension + "_auto_file_." + Extension, 0);
                        ApplicationAssociationToasts.SetValue(@"Applications\" + ExecutableName + "_." + Extension, 0);
                        User_Application_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                        User_Explorer.CreateSubKey("OpenWithList").SetValue("a", ExecutableName);
                        User_Explorer.CreateSubKey("OpenWithProgids").SetValue(Extension + "_auto_file", "0");
                        if (User_Choice != null) User_Explorer.DeleteSubKey("UserChoice");
                        User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", @"Applications\" + ExecutableName);
                    }
                    SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
                }
                catch (Exception excpt)
                {
                    //Your code here
                }
            }
    
      [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
 

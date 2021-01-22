    String App_Exe = "MyApp.exe";
    String App_Path = "%localappdata%;
    SetAssociation_User("myExt", App_Path + App_Exe, App_Exe);
        public static void SetAssociation_User(string Extension, string OpenWith, string ExecutableName)
        {
            try
            {
                RegistryKey User_Extension;
                RegistryKey User_Classes;
                RegistryKey User_AutoFile;
                RegistryKey ApplicationAssociationToasts;
                RegistryKey User_AutoFile_Command;
                RegistryKey User_Explorer;
                RegistryKey User_Explorer_Choice;
                RegistryKey User_Application;
                RegistryKey User_Application_Command;
                //USER
                User_Extension = Registry.CurrentUser.CreateSubKey("." + Extension);
                User_Extension.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true);
                User_Classes.CreateSubKey("." + Extension);
                User_Classes.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_AutoFile = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true).CreateSubKey(Extension + "_auto_file");
                User_AutoFile_Command = User_AutoFile.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                User_AutoFile_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", true);
                ApplicationAssociationToasts.SetValue(Extension + "_auto_file_." + Extension, 0);
                ApplicationAssociationToasts.SetValue(@"Applications\" + ExecutableName + "_." + Extension, 0);
                try
                {
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\Applications", true).CreateSubKey(ExecutableName);
                }
                catch (Exception excpt)
                {
                    Logger.Log_Error(@"Registry.CurrentUser.OpenSubKey(""SOFTWARE\\Classes\\Applications"", true)." + excpt.ToString());
                }
                User_Application = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\Applications", true).CreateSubKey(ExecutableName);
                User_Application_Command = User_Application.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                User_Application_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                User_Explorer = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension);
                User_Explorer.CreateSubKey("OpenWithList").SetValue("a", ExecutableName);
                User_Explorer.CreateSubKey("OpenWithProgids").SetValue(Extension + "_auto_file", "0");
                try
                {
                    User_Explorer_Choice = User_Explorer.OpenSubKey("UserChoice");
                    if (User_Explorer_Choice != null)
                    {
                        var value = User_Explorer_Choice.GetValue("ProgId");
                        Logger.Log_Info("File Association: " + value);
                        User_Explorer.DeleteSubKey("UserChoice");
                    }
                    User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", @"Applications\" + ExecutableName);
                }
                catch (Exception excpt)
                {
                    Logger.Log_Error(excpt.ToString());
                }
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
            catch (Exception excpt)
            {
                Logger.Log_Error("SetAssociation_User: " + excpt.ToString());
            }
        }
      [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
      public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

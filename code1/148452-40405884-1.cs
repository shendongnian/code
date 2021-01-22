    String App_Exe = "MyApp.exe";
    String App_Path = "%localappdata%;
    SetAssociation_User("myExt", App_Path + App_Exe, App_Exe);
    public static void SetAssociation_User(string Extension, string OpenWith, string ExecutableName)
        {
            try
            {
                RegistryKey User_Extension;
                RegistryKey User_Classes;
                RegistryKey User_Classes_Applications;
                RegistryKey User_Classes_Applications_Exe;
                RegistryKey User_AutoFile;
                RegistryKey ApplicationAssociationToasts;
                RegistryKey User_AutoFile_Command;
                RegistryKey User_Explorer;
                RegistryKey User_Choice;
                RegistryKey User_Application_Command;
                //USER
                User_Extension = Registry.CurrentUser.CreateSubKey("." + Extension);
                User_Extension.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true);
                User_Classes.CreateSubKey("." + Extension);
                User_Classes.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_AutoFile = User_Classes.CreateSubKey(Extension + "_auto_file");
                User_AutoFile_Command = User_AutoFile.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                User_AutoFile_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                try
                {
                    ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", true);
                    ApplicationAssociationToasts.SetValue(Extension + "_auto_file_." + Extension, 0);
                    ApplicationAssociationToasts.SetValue(@"Applications\" + ExecutableName + "_." + Extension, 0);
                }
                catch (Exception excpt)
                {
                    Logger.Log_Error(@"ApplicationAssociationToasts: " + excpt.ToString());
                }
                try
                {
                    User_Classes_Applications = User_Classes.CreateSubKey("Applications");
                    User_Classes_Applications_Exe = User_Classes_Applications.CreateSubKey(ExecutableName);
                    User_Application_Command = User_Classes_Applications_Exe.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                    User_Application_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                }
                catch (Exception excpt)
                {
                    Logger.Log_Error(@"User_Classes_Applications: " + excpt.ToString());
                }
                User_Explorer = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension);
                User_Explorer.CreateSubKey("OpenWithList").SetValue("a", ExecutableName);
                User_Explorer.CreateSubKey("OpenWithProgids").SetValue(Extension + "_auto_file", "0");
                try
                {
                    User_Choice = User_Explorer.OpenSubKey("UserChoice");
                    if (User_Choice != null) User_Explorer.DeleteSubKey("UserChoice");
                    User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", @"Applications\" + ExecutableName);
                }
                catch (Exception excpt)
                {
                    Logger.Log_Error(@"UserChoice: " + excpt.ToString());
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

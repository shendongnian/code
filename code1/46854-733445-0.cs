    string tempPath = Directory.CreateDirectory("C:\\path_to_your_folder").FullName;
            //set permissions
            SelectQuery sQuery = new SelectQuery("Win32_Group", "Domain='" + System.Environment.UserDomainName.ToString() + "'");
            try
            {
                DirectoryInfo myDirectoryInfo = new DirectoryInfo("C:\\path_to_your_folder");
                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(sQuery);
                foreach (ManagementObject mObject in mSearcher.Get())
                {
                    string User = System.Environment.UserDomainName + "\\" + mObject["Name"];
                    if(User.StartsWith("your-machine-name\\SQL"))
                        myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.FullControl, AccessControlType.Allow));
                }
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

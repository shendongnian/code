            const string regKeyFolders = @"HKEY_USERS\<SID>\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
            const string regValueAppData = @"Local AppData";
            string[] keys = Registry.Users.GetSubKeyNames();
            List<String> paths = new List<String>();
            foreach (string sid in keys)
            {
                string appDataPath = Registry.GetValue(regKeyFolders.Replace("<SID>", sid), regValueAppData, null) as string;
                if (appDataPath != null)
                {
                    paths.Add(appDataPath);
                }
            }

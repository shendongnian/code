        public static bool CheckSettings()
        {
            var isReset = false;
            try
            {
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            }
            catch (ConfigurationErrorsException ex)
            {
                string filename = string.Empty;
                if (!string.IsNullOrEmpty(ex.Filename))
                {
                    filename = ex.Filename;
                }
                else
                {
                    var innerEx = ex.InnerException as ConfigurationErrorsException;
                    if (innerEx != null && !string.IsNullOrEmpty(innerEx.Filename))
                    {
                        filename = innerEx.Filename;
                    }                   
                }
                if (!string.IsNullOrEmpty(filename))
                {
                    if (System.IO.File.Exists(filename))
                    {
                        var fileInfo = new System.IO.FileInfo(filename);
                        var watcher
                             = new System.IO.FileSystemWatcher(fileInfo.Directory.FullName, fileInfo.Name);
                        System.IO.File.Delete(filename);
                        isReset = true;
                        if (System.IO.File.Exists(filename))
                        {
                            watcher.WaitForChanged(System.IO.WatcherChangeTypes.Deleted);
                        }
                    }
                }
            }
            return isReset;
        }

        public static void PreventMultipleInstance(string applicationId)
        {
            // Under Windows this is:
            //      C:\Users\SomeUser\AppData\Local\Temp\ 
            // Linux this is:
            //      /tmp/
            var temporaryDirectory = Path.GetTempPath();
            // Application ID (Make sure this guid is different accross your different applications!
            var applicationGuid = applicationId + ".process-lock";
            // file that will serve as our lock
            var fileFulePath = Path.Combine(temporaryDirectory, applicationGuid);
            try
            {
                // Prevents other processes from reading from or writing to this file
                var _InstanceLock = new FileStream(fileFulePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                _InstanceLock.Lock(0, 0);
                MonoApp.Logger.LogToDisk(LogType.Notification, "04ZH-EQP0", "Aquired Lock", fileFulePath);
                // todo investigate why we need a reference to file stream. Without this GC releases the lock!
                System.Timers.Timer t = new System.Timers.Timer()
                {
                    Interval = 500000,
                    Enabled = true,
                };
                t.Elapsed += (a, b) =>
                {
                    try
                    {
                        _InstanceLock.Lock(0, 0);
                    }
                    catch
                    {
                        MonoApp.Logger.Log(LogType.Error, "AOI7-QMCT", "Unable to lock file");
                    }
                };
                t.Start();
            }
            catch
            {
                // Terminate application because another instance with this ID is running
                Environment.Exit(102534); 
            }
        }         

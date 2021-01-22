            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            string appPath = dataPath + "\\" + appName;
            // test to see if the folder exists
            if (!System.IO.Directory.Exists(appPath))
            {
                // first run
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(appPath);
            }
            else
            {
                // application has been run
            }

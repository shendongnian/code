        static configurationFileHelper()
        {
            try
            {
                string fullFilename = Application.ProductName + ".exe.config";
                string expectedFilename = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                if (!File.Exists(expectedFilename) && (File.Exists(fullFilename))
                        File.Move(fullFilename, expectedFilename);
            }
            catch { ; }
        }

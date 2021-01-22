        public string GetSSDirectory()
        {
            string sSDirFilePath = string.Empty;
            if (!ConfigurationManager.AppSettings.AllKeys.Contains("SSDirectory"))
            {
                Console.WriteLine("AppSettings does not contain key  \"SSDirectory\"");
            }
            else
            {
                sSDirFilePath = ConfigurationManager.AppSettings["SSDirectory"];
                Console.WriteLine("AppSettings.SSDirectory = \"" + sSDirFilePath + "\"");
            }
            return sSDirFilePath;
        }

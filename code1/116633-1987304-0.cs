        /// <summary>
        /// Gets the path where we store Application Data.
        /// </summary>
        /// <returns>The Application Data path</returns>
        public static string GetAppDataPath()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = System.IO.Path.Combine(dir, "MyCompany\\MyApplication");
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }

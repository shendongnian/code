        /// <summary>
        /// Attempt to empty the folder. Return false if it fails (locked files...).
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns>true on success</returns>
        public static bool EmptyFolder(string pathName)
        {
            bool errors = false;
            DirectoryInfo dir = new DirectoryInfo(pathName);
            foreach (FileInfo fi in dir.EnumerateFiles())
            {
                try
                {
                    fi.IsReadOnly = false;
                    fi.Delete();
                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (fi.Exists)
                    {
                        System.Threading.Thread.Sleep(10);
                        fi.Refresh();
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e.Message);
                    errors = true;
                }
            }
            foreach (DirectoryInfo di in dir.EnumerateDirectories())
            {
                try
                {
                    EmptyFolder(di.FullName);
                    di.Delete();
                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (di.Exists)
                    {
                        System.Threading.Thread.Sleep(10);
                        di.Refresh();
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e.Message);
                    errors = true;
                }
            }
            return !errors;
        }

        private const string TEMPDIRPATH = @"C:\\mytempdir\";
        string tempDirUserPath = Path.Combine(TEMPDIRPATH, HttpContext.Current.User.Identity.Name);
        private void removeTempDirUser(string path)
        {
            try
            {
                Directory.Delete(path);
            }
            catch (Exception)
            {
                //an exception occured while deleting the directory.
            }
        }

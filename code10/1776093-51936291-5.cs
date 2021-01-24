    public static class KnownFoldersExtensions
    {
        public static string Path(this Environment.SpecialFolder folder)
        {
            var path = Environment.GetFolderPath(folder);
            if (!string.IsNullOrEmpty(path))
            {
                return path;
            }
            switch (folder)
            {
                case Environment.SpecialFolder.Cookies:
                    {
                        //detect current OS and give correct folder, here is for example only
                        var defaultRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        return System.IO.Path.Combine(defaultRoot, "Cookies");
                    }
                //case OTHERS:
                //    {
                //        // TO DO
                //    }
                default:
                    {
                        //do something or throw or return null
                        throw new PlatformNotSupportedException(folder.ToString());
                        //return null;
                    }
            }
        }
    }

    public static class AdHelper {
        public static string DefaultRootDse {
            get {
                return Properties.Settings.Default.DefaultRootDomain;
            }
        }
        private static string DefaultUserName {
            get {
                return Properties.Settings.Default.DefaultUserName;
            }
        }
        private static string DefaultPassword {
            get {
                return Properties.Settings.Default.DefaultPassword;
            }
        } 
        public static DirectoryEntry RootDse {
            get {
                if (_rootDse == null)
                    _rootDse = new DirectoryEntry(DefaultRootDse, DefaultUserName, DefaultPassword);
                return _rootDse;
            }
        }
        private static DirectoryEntry _rootDse;
    }

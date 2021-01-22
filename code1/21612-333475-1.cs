       public string GetAppPoolName() {
            string AppPath = Context.Request.ServerVariables["APPL_MD_PATH"];
            AppPath = AppPath.Replace("/LM/", "IIS://localhost/");
            DirectoryEntry root = new DirectoryEntry(AppPath);
            if ((root == null)) {
                return " no object got";
            }
            string AppPoolId = (string)root.Properties["AppPoolId"].Value;
            return AppPoolId;
        }

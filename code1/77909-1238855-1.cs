    [WebMethod]
        public static bool CheckForVersion(string pageName, string versionName)
        {
            PageContentCollection pages = new PageContentCollection().Where("pageName", pageName).Where("versionName", versionName).Load();
            if (pages.Count > 0)
                return true;
            else
                return false;            
        }
                   

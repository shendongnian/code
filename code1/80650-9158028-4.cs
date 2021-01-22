        public bool IsWebsiteExists(string strWebsitename)
        {
            Boolean flagset = false;
            SiteCollection sitecollection = serverMgr.Sites;
            foreach (Site site in sitecollection)
            {
                if (site.Name == strWebsitename.ToString())
                {
                    flagset = true;
                    break;
                }
                else
                {
                    flagset = false;
                }
            }
            return flagset;
        }

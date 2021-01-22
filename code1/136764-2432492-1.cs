                string username;
                string sspURL = "URL where Sharepoint is deployed";
                SPSite site = new SPSite(sspURL);
                SPWeb web = site.OpenWeb();
                SPUser user = web.CurrentUser;
                username = user.LoginName;
                site.AllowUnsafeUpdates = true;

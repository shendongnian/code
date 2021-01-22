        public static void AddComment(string url)
        {
            using (SPSite site = new SPSite(url))
            {
                site.AllowUnsafeUpdates = true;
                using (SPWeb web = site.OpenWeb())
                {
                    web.AllowUnsafeUpdates = true;
                    SPList commentList = web.Lists["Comments"];
                    SPListItem newItem = commentList.AddItem();
                    newItem["Body"] = "body";
                    newItem["Title"] = "title";
                    newItem["PostTitle"] = "2;#post1";
                    newItem.Update();
                }
            }
        }

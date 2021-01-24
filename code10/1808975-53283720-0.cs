                DirectoryEntry adsEntry = new DirectoryEntry("domain", userid, password);
                DirectorySearcher adsSearcher = new DirectorySearcher(adsEntry);
                adsSearcher.Filter = "(&(objectClass=user)(objectCategory=person)(sAMAccountName=" + userid + "))";
            try
            {
                SearchResult adsSearchResult = adsSearcher.FindOne();
                string propertyName = "memberOf";
                ResultPropertyValueCollection rpvcResult = adsSearchResult.Properties[propertyName];
                foreach (Object PropertyValue in rpvcResult)
                {
                    if (PropertyValue.ToString() == "Group Name")
                    {
                        user.Verified = true;
                        user.FullName = GetFullName(userid);
                        adsEntry.Close();
                    } else
                    {
                        user.Verified = false;
                        user.error = "You do not belong to the Group so you cannot do this function";
                    }
                }
            } catch (Exception ex)
            {
                user.error = "Please check your username and password credentials";
                adsEntry.Close();
            }

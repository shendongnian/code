    DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = string.Format("(SAMAccountName={0})", username);
            search.PropertiesToLoad.Add("Name");
            search.PropertiesToLoad.Add("displayName");
            search.PropertiesToLoad.Add("company");
            search.PropertiesToLoad.Add("homePhone");
            search.PropertiesToLoad.Add("mail");
            search.PropertiesToLoad.Add("givenName");
            search.PropertiesToLoad.Add("lastLogon");
            search.PropertiesToLoad.Add("userPrincipalName");
            search.PropertiesToLoad.Add("st");
            search.PropertiesToLoad.Add("sn");
            search.PropertiesToLoad.Add("telephoneNumber");
            search.PropertiesToLoad.Add("postalCode");
            SearchResult result = search.FindOne();
            if (result != null)
            {
                foreach (string key in result.Properties.PropertyNames)
                {
                    // Each property contains a collection of its own
                    // that may contain multiple values
                    foreach (Object propValue in result.Properties[key])
                    {
                        outputString += key + " = " + propValue + ".<br/>";
                    }
                }
            }

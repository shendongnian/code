        public string GetEmaiId(string userId)
        {
            string email = string.Empty;
            DirectorySearcher objsearch = new DirectorySearcher();
            string strrootdse = objsearch.SearchRoot.Path;
            DirectoryEntry objdirentry = new DirectoryEntry(strrootdse);
            objsearch.Filter = "(& (cn=" + userId + ")(objectClass=user))";
            objsearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            objsearch.PropertiesToLoad.Add("cn");
            objsearch.PropertyNamesOnly = true;
            objsearch.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;
            objsearch.Sort.PropertyName = "cn";
            SearchResultCollection colresults = objsearch.FindAll();
            foreach (SearchResult objresult in colresults)
            {
                email = objresult.GetDirectoryEntry().Properties["mail"].Value.ToString();
            }
            objsearch.Dispose();
            return email;
        }

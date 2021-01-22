        public bool FindUser2(string userName)
        {
            try
            {
                DirectoryContext context = new DirectoryContext(
                    DirectoryContextType.Domain,
                    domainName,
                    domainName + @"\" + domainUserName,
                    domainPassword);
                DirectoryEntry domainEntry = Domain.GetDomain(context).GetDirectoryEntry();
                DirectorySearcher searcher = new DirectorySearcher(domainEntry,
                                                                   "(|(objectCategory=user)(cn=" + domainUserName + "))");
                SearchResult searchResult = searcher.FindOne();
                return searchResult != null;
            }
            catch
            {
                return false;
            }
        }

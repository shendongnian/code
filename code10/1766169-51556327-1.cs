    class Searcher {
        public string Filter { get; set; }
        public Searcher(string filter) {
            Filter = filter;
        }
        public List<Group> Search() {
            return Search(null, null);
        }
        protected List<Group> Search(string baseDn, int? parentId) {
            //In the 1st call, baseDN will be null, so we use the filter
            //TODO: dispose DirectorySearcher and DirectoryEntry
            DirectorySearcher search = new DirectorySearcher();
            if (string.IsNullOrEmpty(baseDn)) {
                search.Filter = $"(&(objectClass=group){Filter})";
            } else {
                DirectoryEntry entryRoot = new DirectoryEntry("LDAP://" + baseDn);
                //We only iterate across groups
                if (!IsGroup(entryRoot))
                    return null;
                search.SearchRoot = entryRoot;
            }
            
            SearchResultCollection results = search.FindAll();
            int i = 1;
            var groups = new List<Group>(results.Count);
            foreach (SearchResult result in results) {
                using (DirectoryEntry entry = result.GetDirectoryEntry()) {
                    Group group = new Group {
                        Id = i,
                        Name = entry.Properties["cn"].Value.ToString(),
                        ParentId = parentId
                    };
                    var members = entry.Properties["member"];
                    foreach (string member in members) {
                        var subgroups = Search(member, i);
                        if (subgroups != null)
                            group.Members.AddRange(subgroups);
                    }
                    groups.Add(group);
                    i++;
                }
            }
            return groups;
        }
        private bool IsGroup(DirectoryEntry entry) {
            return entry.Properties["objectClass"].Cast<string>().Any(x => x == "group");
        }
    }

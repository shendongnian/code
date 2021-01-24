    var groupname = "IT Team";
    var members = new List<string>();
    using (var searcher = new DirectorySearcher(new DirectoryEntry("GC://dept.mycomp.net"))) {
        searcher.Filter = "(&(objectCategory=group)(objectClass=group)(cn=" + groupname + "))";
        searher.PropertiesToLoad.Add("member"); //only get the member attribute
        
        using (SearchResult result = searcher.FindOne()) {
            foreach (var member in result.Properties["member"]) {
                members.Add(member);
            }
        }
    }

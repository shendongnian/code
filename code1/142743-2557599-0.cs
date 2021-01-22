    using (var e = new DirectoryEntry("LDAP://DC=example,DC=com"))
		using (var s = new DirectorySearcher(e)) {
			s.Filter = "(objectClass=printQueue)";
			
			using (var c = s.FindAll()) {
				WL("Returned {0} objects", c.Count);
				foreach (SearchResult r in c) {
					WL("{0}", r.Path);
				}
			}
		}

    private struct PageNameOnSite
    {
        public int siteId;
        public string pageName;
        public override bool Equals(object obj) {
          if ( !obj is PageNameOnSite) { return false; }
          var other = (PageNameOnSite)obj;
          return sideId == other.siteId && StringComparer.Oridinal.Equals(pageName, other.pageName);
       }
       public override int GetHashCode() { return sideId + pageName.GetHashCode(); }
    }

    class Package
    {
        public HashSet<GroupList> groupList;
        public override bool Equals(object o)
        {
            Package p = o as Package;
            if (p == null) return false;
            return groupList.SetEquals(p.groupList);
        }
        public override int GetHashCode()
        {
            return groupList.Aggregate(0, (hash, g) => hash ^ g.GetHashCode());
        }
    }
    
    class GroupList
    {
       public HashSet<Feature> featureList;
        public override bool Equals(object o)
        {
            GroupList g = o as GroupList;
            if (g == null) return false;
            return featureList.SetEquals(g.featureList);
        }
        public override int GetHashCode()
        {
            return featureList.Aggregate(0, (hash, f) => hash ^ f.GetHashCode());
        }
    }
    
    class Feature
    {
        public int qty;
        public override bool Equals(object o)
        {
            Feature f = o as Feature;
            if (f == null) return false;
            return qty == f.qty;
        }
        public override int GetHashCode()
        {
            return qty.GetHashCode();
        }
    }
